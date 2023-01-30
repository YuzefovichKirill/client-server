using System;
using FluentValidation;

namespace Server.Application.FridgeProducts.Commands.CreateFridgeProduct
{
    public class CreateFridgeProductCommandValidator : AbstractValidator<CreateFridgeProductCommand>
    {
        public CreateFridgeProductCommandValidator()
        {
            RuleFor(createFridgeProductCommand =>
                createFridgeProductCommand.ProductId).NotEqual(Guid.Empty);
            RuleFor(createFridgeProductCommand =>
                createFridgeProductCommand.FridgeId).NotEqual(Guid.Empty);
            RuleFor(createFridgeProductCommand =>
                createFridgeProductCommand.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}
