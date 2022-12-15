using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.UserTasks.Commands.Create
{
    public class CreateFacultyCommandValidator : AbstractValidator<CreateUserTaskCommand>
    {
        public CreateFacultyCommandValidator()
        {
            RuleFor(createUserTaskCommand =>
                createUserTaskCommand.Task).NotEmpty().MaximumLength(4096);
            RuleFor(createUserTaskCommand =>
                createUserTaskCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
