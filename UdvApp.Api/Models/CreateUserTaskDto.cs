using AutoMapper;
using UdvApp.Application.Common.Mappings;
using UdvApp.Application.UserTasks.Commands.Create;
using UdvApp.Domain;

namespace UdvApp.Api.Models
{
    public class CreateUserTaskDto : IMapWith<CreateUserTaskCommand>
    {
        public string Task { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserTaskDto, CreateUserTaskCommand>()
                .ForMember(command => command.Task, opt =>
                opt.MapFrom(taskDto => taskDto.Task))
                .ForMember(command => command.Status, opt =>
                opt.MapFrom(taskDto => taskDto.Status));
        }
    }
}
