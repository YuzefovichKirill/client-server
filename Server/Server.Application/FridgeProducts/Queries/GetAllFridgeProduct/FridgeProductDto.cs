using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Domain;

namespace Server.Application.FridgeProducts.Queries.GetAllFridgeProduct
{
    public class FridgeProductDto : IMapWith<FridgeProduct>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FridgeProduct, FridgeProductDto>();
        }
    }
}
