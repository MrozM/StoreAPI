using FluentValidation;

namespace Core.Models.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator(IAccountService accountService)
    {
        RuleFor(u => u.Email).NotEmpty().EmailAddress();

        RuleFor(u => u.Password).NotEmpty().MinimumLength(6);

        RuleFor(u => u.ConfirmPassword).Equal(u => u.Password);

        RuleFor(u => u.Email).Custom((value, context) =>
        {
           var emailInUse = accountService.CheckIfMailExist(value);

           if (emailInUse)
           {
               context.AddFailure("That email is taken");
           }
        });
    }
}