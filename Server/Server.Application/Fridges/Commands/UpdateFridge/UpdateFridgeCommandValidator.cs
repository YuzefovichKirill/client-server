using System;
using FluentValidation;
namespace Server.Application.Fridges.Commands.UpdateFridge
{
    public class UpdateFridgeCommandValidator : AbstractValidator<UpdateFridgeCommand>
    {
        public UpdateFridgeCommandValidator()
        {
            RuleFor(updateFridgeCommand =>
                updateFridgeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateFridgeCommand =>
                updateFridgeCommand.FridgeModelId).NotEqual(Guid.Empty);
            RuleFor(updateFridgeCommand =>
                updateFridgeCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(updateFridgeCommand =>
                updateFridgeCommand.OwnerName).NotEmpty().MaximumLength(20);
        }
    }
}
