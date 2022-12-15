using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Commands.Update
{
    public class UpdateUserTaskCommandValidator : AbstractValidator<UpdateUserTaskCommand>
    {
        public UpdateUserTaskCommandValidator() 
        {
            RuleFor(command =>command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        }
    }
}
