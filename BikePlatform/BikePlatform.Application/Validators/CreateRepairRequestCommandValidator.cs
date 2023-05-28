using BikePlatform.Application.CreateRepairRequest;
using BikePlatform.Application.Validators.Internal;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Application.Validators
{
    public class CreateRepairRequestCommandValidator : Validator<CreateRepairRequestCommand>
    {
        public CreateRepairRequestCommandValidator()
        {
            RuleFor(command => command).NotNull();
            RuleFor(command => command.Name).NotNull().NotEmpty().MinimumLength(5)
                .WithMessage("Name is required and must have a minimum length of 4 characters");
            RuleFor(command => command.Email)
                .NotNull().NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not a valid email address.");
            RuleFor(command => command.Description)
                .NotNull().NotEmpty().WithMessage("Description is required");
        }
    }
}
