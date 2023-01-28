﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Fridges.Commands.UpdateFridge
{
    public class UpdateFridgeCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
    }
}
