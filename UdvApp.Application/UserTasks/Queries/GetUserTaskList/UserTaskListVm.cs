using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskList
{
    public class UserTaskListVm
    {
        public IList<UserTaskLookupDto> UserTasks { get; set; }
    }
}
