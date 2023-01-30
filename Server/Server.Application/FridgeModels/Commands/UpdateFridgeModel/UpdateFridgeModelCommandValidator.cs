using System;
using FluentValidation;

namespace Server.Application.FridgeModels.Commands.UpdateFridgeModel
{
    public class UpdateFridgeModelCommandValidator : AbstractValidator<UpdateFridgeModelCommand>
    {
        public UpdateFridgeModelCommandValidator()
        {
            RuleFor(updateFridgeModelCommand =>
                updateFridgeModelCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateFridgeModelCommand =>
                updateFridgeModelCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(updateFridgeModelCommand =>
                updateFridgeModelCommand.Year).NotEmpty();
        }
    }
}
