using System;
using FluentValidation;

namespace Server.Application.FridgeProducts.Commands.UpdateFridgeProduct
{
    public class UpdateFridgeProductCommandValidator : AbstractValidator<UpdateFridgeProductCommand>
    {
        public UpdateFridgeProductCommandValidator()
        {
            RuleFor(updateFridgeProductCommand =>
                updateFridgeProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateFridgeProductCommand =>
                updateFridgeProductCommand.ProductId).NotEqual(Guid.Empty);
            RuleFor(updateFridgeProductCommand =>
                updateFridgeProductCommand.FridgeId).NotEqual(Guid.Empty);
            RuleFor(updateFridgeProductCommand =>
                updateFridgeProductCommand.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}
