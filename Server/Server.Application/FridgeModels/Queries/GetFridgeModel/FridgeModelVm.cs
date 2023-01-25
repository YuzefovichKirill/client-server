using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    // as example
    public class FridgeModelVm : IMapWith<FridgeModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FridgeModel, FridgeModelVm>()
                .ForMember(fridgeModelDto => fridgeModelDto.Id,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Id))
                .ForMember(fridgeModelDto => fridgeModelDto.Name,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Name))
                .ForMember(fridgeModelDto => fridgeModelDto.Year,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Year));
        }
    }
}
