﻿using Server.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeProducts.Queries.GetFridgeProduct
{
    public class FridgeProductVm : IMapWith<FridgeProductVm>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FridgeId { get; set; }
        public int Quantity { get; set; }
        public int DefaultQuantity { get; set; }
        public string FridgeName { get; set; }
    }
}