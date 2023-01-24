using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Commands.CreateFridgeModel
{
    public class CreateFridgeModelCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
