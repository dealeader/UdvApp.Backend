using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Domain;

namespace UdvApp.Application.Interfaces
{
    public interface IUdvAppDbContext
    {
        DbSet<UserTask> UserTasks { get; set; }
        DbSet<Faculty> Faculties { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken );

    }
}
