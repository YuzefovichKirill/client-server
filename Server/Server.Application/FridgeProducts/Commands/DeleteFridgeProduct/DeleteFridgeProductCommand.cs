﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeProducts.Commands.DeleteFridgeProduct
{
    public class DeleteFridgeProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
