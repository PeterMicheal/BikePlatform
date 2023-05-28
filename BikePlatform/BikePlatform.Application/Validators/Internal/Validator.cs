using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Application.Validators.Internal
{
    public class Validator<T> : AbstractValidator<T>, IValidator<T>
    {
        /// <summary>
        /// Validates the specified instance
        /// </summary>
        /// <param name="instance">The object to validate</param>
        /// <returns>A ValidationResult object containing any validation failures</returns>
        public new ValidationResult Validate(T instance)
        {
            var fluentValidationResult = base.Validate(instance);
            return new ValidationResult(fluentValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
