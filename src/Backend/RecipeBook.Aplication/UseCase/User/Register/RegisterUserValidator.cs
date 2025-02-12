using FluentValidation;
using RecipeBook.Communication.Requests;
using RecipeBook.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Aplication.UseCase.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator() 
        {
            RuleFor(User => User.Name)
                .NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY)
                .MaximumLength(100).WithMessage("Name must be less than 100 characters");

            RuleFor(User => User.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);

            RuleFor(User => User.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
        }
    }
}
