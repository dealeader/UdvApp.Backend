using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.Faculties.Commands.Update
{
    public class UpdateFacultyCommandValidator : AbstractValidator<UpdateFacultyCommand>
    {
        public UpdateFacultyCommandValidator() 
        {
            RuleFor(command =>command.Id).NotEqual(Guid.Empty);
        }
    }
}
