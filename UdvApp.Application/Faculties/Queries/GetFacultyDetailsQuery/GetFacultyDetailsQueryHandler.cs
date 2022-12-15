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

namespace UdvApp.Application.Faculties.Queries.GetFacultyDetailsQuery
{
    public class GetFacultyDetailsQueryHandler : IRequestHandler<GetFacultyDetailsQuery, FacultyDetailsVm>
    {
        private readonly IUdvAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFacultyDetailsQueryHandler(IUdvAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FacultyDetailsVm> Handle(GetFacultyDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Faculties.FirstOrDefaultAsync(fac => fac.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Faculty), request.Id);
            }

            return _mapper.Map<FacultyDetailsVm>(entity);
        }
    }
}
