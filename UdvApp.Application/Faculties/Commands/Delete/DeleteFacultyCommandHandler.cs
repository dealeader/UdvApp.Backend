using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.Faculties.Commands.Delete
{
    public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand>
    {
        private readonly IUdvAppDbContext _dbContext;

        public DeleteFacultyCommandHandler(IUdvAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Faculties.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserTask), request.Id);
            }

            _dbContext.Faculties.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
