using AutoMapper;
using UdvApp.Application.Common.Mappings;
using UdvApp.Application.UserTasks.Commands.Create;
using UdvApp.Application.UserTasks.Commands.Update;

namespace UdvApp.Api.Models
{
    public class UpdateUserTaskDto : IMapWith<UpdateUserTaskCommand>
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserTaskDto, UpdateUserTaskCommand>()
                .ForMember(command => command.Task, opt =>
                opt.MapFrom(taskDto => taskDto.Task))
                .ForMember(command => command.Status, opt =>
                opt.MapFrom(taskDto => taskDto.Status))
                .ForMember(command => command.Id, opt =>
                opt.MapFrom(taskDto => taskDto.Id));
        }
    }
}
