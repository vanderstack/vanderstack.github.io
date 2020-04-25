using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public class CommandValidationException : DomainException
    {
        public IDictionary<string, string[]> ValidationFailures { get; private set; }
        
        public CommandValidationException(string message, ValidationException validationException) : base(message, validationException)
        {
            if (validationException == null) throw new ArgumentNullException(nameof(validationException));

            ValidationFailures = !validationException.Errors.Any()
                ? new Dictionary<string, string[]>()
                : validationException.Errors
                    .GroupBy(validationFailure =>
                        validationFailure.PropertyName
                    )
                    .ToDictionary(group =>
                        group.Key
                        , group => group.Select(x => x.ErrorMessage).ToArray()
                    )
            ;
        }
    }
}
