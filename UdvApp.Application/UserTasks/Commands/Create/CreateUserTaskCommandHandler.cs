using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.UserTasks.Commands.Create
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, Guid>
    {
        private readonly IUdvAppDbContext _dbContext;

        public CreateUserTaskCommandHandler(IUdvAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var usertask = new UserTask
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null,
                UserId = request.UserId,
                Status = request.Status,
                Task = request.Task
            };

            await _dbContext.UserTasks.AddAsync(usertask, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken); 

            return usertask.Id;
        }
    }
}
