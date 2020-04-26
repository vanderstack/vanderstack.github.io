using System;
using Xunit;
using System.Threading.Tasks;
using System.Threading;
using VanderStack.Shared.Infrastructure.Exceptions;
using Moq;

namespace VanderStack.Tests.Infrastructure.Exceptions
{
    public class UnobservedExceptionHandlerTest
    {
        [Fact]
        public async Task Handler_Handles_UnobservedException()
        {
            // Arrange
            var manualResetEvent = new ManualResetEvent(initialState: false);
            var handler = new Mock<IUnobservedExceptionHandler>();
            handler
                .Setup(handler =>
                    handler.OnUnobservedTaskException(It.IsAny<object>(), It.IsAny<UnobservedTaskExceptionEventArgs>())
                )
                .Callback(() => manualResetEvent.Set())
            ;

            var subjectUnderTest = new UnobservedExceptionHandlerHostedService(handler.Object);


            // Act
            try
            {
                await subjectUnderTest.StartAsync(CancellationToken.None);

                Action actionUnderTest = () =>
                {
                    var exceptionGeneratingTask = Task.Run(() =>
                    {
                        throw new NotImplementedException();
                    });
                    ((IAsyncResult)exceptionGeneratingTask).AsyncWaitHandle.WaitOne(); // Wait for the task to complete
                };

                actionUnderTest.Invoke();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            finally
            {
                await subjectUnderTest.StopAsync(CancellationToken.None);
            }

            // Assert
            Assert.True(manualResetEvent.WaitOne(10000));
        }
    }
}
