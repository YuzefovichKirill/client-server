using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Commands.UpdateFridgeModel
{
    public class UpdateFridgeModelCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
