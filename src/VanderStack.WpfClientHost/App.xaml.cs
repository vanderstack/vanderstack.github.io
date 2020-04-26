// <copyright file="App.xaml.cs" company="Steve Sanderson and Jan-Willem Spuij">
// Copyright 2020 Steve Sanderson and Jan-Willem Spuij
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace VanderStack.WpfClientHost
{
    using Microsoft.Extensions.Logging;
    using Serilog;
    using System.Windows;
    using VanderStack.WpfClientHost.Infrastructure.Exceptions;
    using VanderStack.Shared.Infrastructure.Exceptions;
    using System.IO;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        private WpfGlobalExceptionManager _exceptionManager;

        public App()
        {
            // Configure Logging for Exceptions which occur outside of Blazor
            Log.Logger =
                new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File(
                    Path.Combine(Path.GetTempPath(), $"{nameof(VanderStack)}.log")
                    , rollingInterval: RollingInterval.Day
                    , retainedFileCountLimit: 7
                )
                .CreateLogger()
            ;

            var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);

            _exceptionManager = new WpfGlobalExceptionManager(
                this
                , new UnobservedExceptionLoggingHandler(loggerFactory.CreateLogger<IUnobservedExceptionHandler>())
                , new DispatcherUnhandledExceptionLoggingHandler(loggerFactory.CreateLogger<IDispatcherUnhandledExceptionHandler>())
                , new AppDomainUnhandledExceptionLoggingHandler(loggerFactory.CreateLogger<IAppDomainUnhandledExceptionHandler>())
            );

            _exceptionManager.Start();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        /// <summary>
        /// Raises the application exit event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _exceptionManager.Dispose();
            System.Environment.Exit(0);
        }
    }
}
