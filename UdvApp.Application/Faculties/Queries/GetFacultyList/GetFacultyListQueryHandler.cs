using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UdvApp.Application.Interfaces;

namespace UdvApp.Application.Faculties.Queries.GetFacultyList
{
    public class GetFacultyListQueryHandler : IRequestHandler<GetFacultyListQuery, FacultyListVm>
    {
        private readonly IUdvAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFacultyListQueryHandler(IUdvAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FacultyListVm> Handle(GetFacultyListQuery request, CancellationToken cancellationToken)
        {
            var facultiesQuery = await _dbContext.Faculties
                .ProjectTo<FacultyLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new FacultyListVm { Faculties = facultiesQuery };
        }
    }
}
