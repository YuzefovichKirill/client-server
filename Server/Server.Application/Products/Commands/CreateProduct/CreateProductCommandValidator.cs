using FluentValidation;
using System;

namespace Server.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand =>
                createProductCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(createProductCommand =>
                createProductCommand.DefaultQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
