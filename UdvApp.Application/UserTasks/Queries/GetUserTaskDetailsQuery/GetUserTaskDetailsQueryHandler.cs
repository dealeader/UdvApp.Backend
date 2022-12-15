using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskDetailsQuery
{
    public class GetUserTaskDetailsQueryHandler : IRequestHandler<GetUserTaskDetailsQuery, UserTaskDetailsVm>
    {
        private readonly IUdvAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserTaskDetailsQueryHandler(IUdvAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserTaskDetailsVm> Handle(GetUserTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.UserTasks.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId || entity.FacultyId != request.FacultyId)
            {
                throw new NotFoundException(nameof(UserTask), request.Id);
            }

            return _mapper.Map<UserTaskDetailsVm>(entity);
        }
    }
}
