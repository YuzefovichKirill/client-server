using System;
using FluentValidation;

namespace Server.Application.FridgeModels.Commands.DeleteFridgeModel
{
    public class DeleteFridgeModelCommandValidator : AbstractValidator<DeleteFridgeModelCommand>
    {
        public DeleteFridgeModelCommandValidator()
        {
            RuleFor(deleteFridgeModelCommand =>
                deleteFridgeModelCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
