using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Commands.Create
{
    public class CreateUserTaskCommandValidator : AbstractValidator<CreateUserTaskCommand>
    {
        public CreateUserTaskCommandValidator()
        {
            RuleFor(createUserTaskCommand =>
                createUserTaskCommand.Task).NotEmpty().MaximumLength(4096);
            RuleFor(createUserTaskCommand =>
                createUserTaskCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
