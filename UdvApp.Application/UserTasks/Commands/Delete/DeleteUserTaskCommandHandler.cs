using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.UserTasks.Commands.Delete
{
    public class DeleteUserTaskCommandHandler : IRequestHandler<DeleteUserTaskCommand>
    {
        private readonly IUdvAppDbContext _dbContext;

        public DeleteUserTaskCommandHandler(IUdvAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.UserTasks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId || entity.FacultyId != request.FacultyId)
            {
                throw new NotFoundException(nameof(UserTask), request.Id);
            }

            _dbContext.UserTasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
