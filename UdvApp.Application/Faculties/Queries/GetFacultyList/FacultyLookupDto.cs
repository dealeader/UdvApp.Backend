using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Mappings;
using UdvApp.Domain;

namespace UdvApp.Application.Faculties.Queries.GetFacultyList
{
    public class FacultyLookupDto : IMapWith<Faculty>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Faculty, FacultyLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.Title,
                opt => opt.MapFrom(task => task.Title))
                .ForMember(taskDto => taskDto.Description,
                opt => opt.MapFrom(task => task.Description));
        }
    }
}
