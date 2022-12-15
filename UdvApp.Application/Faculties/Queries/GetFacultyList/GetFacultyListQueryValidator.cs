using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.Faculties.Queries.GetFacultyList
{
    public class GetFacultyListQueryValidator : AbstractValidator<GetFacultyListQuery>
    {
        public GetFacultyListQueryValidator()
        {
            //RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
