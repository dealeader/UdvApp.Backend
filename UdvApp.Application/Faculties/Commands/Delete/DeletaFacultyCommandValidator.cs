using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.Faculties.Commands.Delete
{
    public class DeletaFacultyCommandValidator : AbstractValidator<DeleteFacultyCommand>
    {
        public DeletaFacultyCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        }
    }
}
