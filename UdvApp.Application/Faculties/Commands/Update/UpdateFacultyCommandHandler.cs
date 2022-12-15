using MediatR;
using Microsoft.EntityFrameworkCore;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.Faculties.Commands.Update
{
    public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand>
    {
        private readonly IUdvAppDbContext _dbContext;

        public UpdateFacultyCommandHandler(IUdvAppDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Faculties.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Faculties), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Curators = request.CuratorsIds;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
