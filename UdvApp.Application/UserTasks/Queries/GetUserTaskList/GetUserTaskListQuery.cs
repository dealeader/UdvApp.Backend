using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskList
{
    public class GetUserTaskListQuery : IRequest<UserTaskListVm>
    {
        public Guid UserId { get; set; }
    }
}
