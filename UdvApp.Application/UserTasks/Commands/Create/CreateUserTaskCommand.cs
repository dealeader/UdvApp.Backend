using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Commands.Create
{
    public class CreateUserTaskCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
    }
}
