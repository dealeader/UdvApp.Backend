using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.Faculties.Queries.GetFacultyDetailsQuery
{
    public class GetFacultyDetailsQuery : IRequest<FacultyDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
