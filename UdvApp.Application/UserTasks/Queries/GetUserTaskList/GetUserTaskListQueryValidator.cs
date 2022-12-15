using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskList
{
    public class GetUserTaskListQueryValidator : AbstractValidator<GetUserTaskListQuery>
    {
        public GetUserTaskListQueryValidator()
        {
            //RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
