using FluentValidation;
using Infrastructure.Models;
using Store.Dtos;

namespace Core.Models.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).NotEmpty();
    }
}