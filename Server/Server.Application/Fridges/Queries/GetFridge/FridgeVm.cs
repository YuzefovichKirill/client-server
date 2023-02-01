using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Domain;

namespace Server.Application.Fridges.Queries.GetFridge
{
    public class FridgeVm : IMapWith<Fridge>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fridge, FridgeVm>();
        }
    }
}
