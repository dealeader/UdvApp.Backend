using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Domain;

namespace UdvApp.Application.Faculties.Commands.Create
{
    public class CreateFacultyCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Curator> CuratorsIds { get; set; }
    }
}
