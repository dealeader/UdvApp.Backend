using AutoMapper;
using UdvApp.Application.Common.Mappings;
using UdvApp.Domain;

namespace UdvApp.Application.Faculties.Queries.GetFacultyDetailsQuery
{
    public class FacultyDetailsVm : IMapWith<Faculty>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Guid> Curators { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Faculty, FacultyDetailsVm>()
                .ForMember(taskVm => taskVm.Title,
                opt => opt.MapFrom(task => task.Title))
                .ForMember(taskVm => taskVm.Description,
                opt => opt.MapFrom(task => task.Description))
                .ForMember(taskVm => taskVm.Id,
                opt => opt.MapFrom(task => task.Id))
                .ForMember(taskVm => taskVm.CreationDate,
                opt => opt.MapFrom(task => task.CreationDate))
                .ForMember(taskVm => taskVm.EditDate,
                opt => opt.MapFrom(task => task.EditDate))
                .ForMember(taskVm => taskVm.Curators,
                opt => opt.MapFrom(task => task.Curators));
        }
    }
}