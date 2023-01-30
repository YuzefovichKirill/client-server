using System;
using FluentValidation;

namespace Server.Application.FridgeModels.Commands.CreateFridgeModel
{
    public class CreateFridgeModelCommandValidator : AbstractValidator<CreateFridgeModelCommand>
    {
        public CreateFridgeModelCommandValidator()
        {
            RuleFor(createFridgeModelCommand =>
                createFridgeModelCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(createFridgeModelCommand =>
                createFridgeModelCommand.Year).NotEmpty();
        }
    }
}
