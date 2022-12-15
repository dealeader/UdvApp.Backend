using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.Faculties.Queries.GetFacultyDetailsQuery
{
    public class GetFacultyDetailsQueryValidator : AbstractValidator<GetFacultyDetailsQuery>
    {
        public GetFacultyDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
        }
    }
}
