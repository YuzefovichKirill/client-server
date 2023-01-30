using System;
using FluentValidation;

namespace Server.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand =>
                updateProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProductCommand =>
                updateProductCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(updateProductCommand =>
                updateProductCommand.DefaultQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
