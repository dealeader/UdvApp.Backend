using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Commands.Delete
{
    public class DeleteUserTaskCommandValidator : AbstractValidator<DeleteUserTaskCommand>
    {
        public DeleteUserTaskCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        }
    }
}
