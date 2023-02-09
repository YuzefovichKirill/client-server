using System;
using FluentValidation;
namespace Server.Application.Fridges.Commands.CreateFridge
{
    public class CreateFridgeCommandValidator : AbstractValidator<CreateFridgeCommand>
    {
        public CreateFridgeCommandValidator()
        {
            RuleFor(createFridgeCommand =>
                createFridgeCommand.Name).NotEmpty().MaximumLength(50);
        }
    }
}
