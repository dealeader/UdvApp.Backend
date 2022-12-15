using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Commands.Update
{
    public class UpdateUserTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FacultyId { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
    }
}
