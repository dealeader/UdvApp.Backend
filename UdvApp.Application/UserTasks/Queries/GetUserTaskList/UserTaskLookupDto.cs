using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Mappings;
using UdvApp.Domain;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskList
{
    public class UserTaskLookupDto : IMapWith<UserTask>
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTask, UserTaskLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.Status,
                opt => opt.MapFrom(task => task.Status))
                .ForMember(taskDto => taskDto.Task,
                opt => opt.MapFrom(task => task.Task));
        }
    }
}
