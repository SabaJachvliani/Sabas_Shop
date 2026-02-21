using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Public.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");
                

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
                
        }
    }
}
