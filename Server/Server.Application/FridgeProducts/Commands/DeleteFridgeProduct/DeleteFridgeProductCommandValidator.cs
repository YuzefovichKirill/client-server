using System;
using FluentValidation;

namespace Server.Application.FridgeProducts.Commands.DeleteFridgeProduct
{
    public class DeleteFridgeProductCommandValidator : AbstractValidator<DeleteFridgeProductCommand>
    {
        public DeleteFridgeProductCommandValidator()
        {
            RuleFor(deleteFridgeProductCommand =>
                deleteFridgeProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
