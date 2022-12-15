using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.Faculties.Commands.Create
{
    public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand, Guid>
    {
        private readonly IUdvAppDbContext _dbContext;

        public CreateFacultyCommandHandler(IUdvAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = new Faculty
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow,
                EditDate = null,
                Curators = request.CuratorsIds,
                Description = request.Description,
                Title = request.Title,
            };

            await _dbContext.Faculties.AddAsync(faculty, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken); 

            return faculty.Id;
        }
    }
}
