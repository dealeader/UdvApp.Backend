using AutoMapper;
using UdvApp.Application.Common.Mappings;
using UdvApp.Domain;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskDetailsQuery
{
    public class UserTaskDetailsVm : IMapWith<UserTask>
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTask, UserTaskDetailsVm>()
                .ForMember(taskVm => taskVm.Task,
                opt => opt.MapFrom(task => task.Task))
                .ForMember(taskVm => taskVm.Status,
                opt => opt.MapFrom(task => task.Status))
                .ForMember(taskVm => taskVm.Id,
                opt => opt.MapFrom(task => task.Id))
                .ForMember(taskVm => taskVm.CreationDate,
                opt => opt.MapFrom(task => task.CreationDate))
                .ForMember(taskVm => taskVm.EditDate,
                opt => opt.MapFrom(task => task.EditDate));
        }
    }
}