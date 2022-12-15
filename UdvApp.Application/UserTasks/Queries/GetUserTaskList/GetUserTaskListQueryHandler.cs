using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdvApp.Application.Interfaces;

namespace UdvApp.Application.UserTasks.Queries.GetUserTaskList
{
    public class GetUserTaskListQueryHandler : IRequestHandler<GetUserTaskListQuery, UserTaskListVm>
    {
        private readonly IUdvAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserTaskListQueryHandler(IUdvAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserTaskListVm> Handle(GetUserTaskListQuery request, CancellationToken cancellationToken)
        {
            var userTasksQuery = await _dbContext.UserTasks.Where(task => task.UserId == request.UserId)
                .ProjectTo<UserTaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new UserTaskListVm { UserTasks = userTasksQuery };
        }
    }
}
