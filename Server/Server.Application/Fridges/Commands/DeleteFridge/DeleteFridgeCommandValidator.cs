using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Fridges.Commands.DeleteFridge
{
    public class DeleteFridgeCommandValidator : AbstractValidator<DeleteFridgeCommand>
    {
        public DeleteFridgeCommandValidator()
        {
            RuleFor(deleteFridgeCommand =>
                deleteFridgeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
