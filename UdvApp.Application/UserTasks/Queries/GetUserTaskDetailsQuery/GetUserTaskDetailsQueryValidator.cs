using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskDetailsQuery
{
    public class GetUserTaskDetailsQueryValidator : AbstractValidator<GetUserTaskDetailsQuery>
    {
        public GetUserTaskDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
