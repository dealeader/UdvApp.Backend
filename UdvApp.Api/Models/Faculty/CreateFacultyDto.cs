using AutoMapper;
using UdvApp.Application.Common.Mappings;
using UdvApp.Application.Faculties.Commands.Create;
using UdvApp.Domain;

namespace UdvApp.Api.Models.Faculty
{
    public class CreateFacultyDto : IMapWith<CreateFacultyCommand>
    {
        public List<Curator> Curators { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFacultyDto, CreateFacultyCommand>()
                .ForMember(command => command.Title, opt =>
                opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(command => command.Description, opt =>
                opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(command => command.CuratorsIds, opt =>
                opt.MapFrom(taskDto => taskDto.Curators));
        }
    }
}
