using AutoMapper;
using Server.Application.FridgeModels.Commands.UpdateFridgeModel;
using Server.Application.Common.Mappings;


namespace Server.WebAPI.Models
{
    public class UpdateFridgeModelDto : IMapWith<UpdateFridgeModelCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFridgeModelDto, UpdateFridgeModelCommand>()
                .ForMember(updateFridgeModelCommand => updateFridgeModelCommand.Id,
                    opt => opt.MapFrom(updateFridgeModelDto => updateFridgeModelDto.Id))
                .ForMember(updateFridgeModelCommand => updateFridgeModelCommand.Name,
                    opt => opt.MapFrom(updateFridgeModelDto => updateFridgeModelDto.Name))
                .ForMember(updateFridgeModelCommand => updateFridgeModelCommand.Year,
                    opt => opt.MapFrom(updateFridgeModelDto => updateFridgeModelDto.Year));
        }
    }
}
