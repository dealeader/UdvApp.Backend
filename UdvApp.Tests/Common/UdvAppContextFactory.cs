using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Domain;
using UdvApp.Persistence;

namespace UdvApp.Tests.Common
{
    public class UdvAppContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid TestFacultyId = Guid.NewGuid();

        public static Guid UserTaskIdForDelete = Guid.NewGuid();
        public static Guid UserTaskIdForUpdate = Guid.NewGuid();

        public static UdvAppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<UdvAppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new UdvAppDbContext(options);
            context.Database.EnsureCreated();

            context.UserTasks.AddRange(
                new UserTask 
                {
                    CreationDate = DateTime.Now,
                    Task = "testtask",
                    Status = "open",
                    EditDate = null,
                    Id = Guid.Parse("5AA2040D-2283-40E1-BD7A-45612A01921E"),
                    UserId = UserAId,
                    FacultyId = TestFacultyId
                },
                new UserTask
                {
                    CreationDate = DateTime.Now,
                    Task = "testtask2",
                    Status = "open",
                    EditDate = null,
                    Id = Guid.Parse("0FDE4386-E611-4DD2-B981-96C54C115B62"),
                    UserId = UserBId,
                    FacultyId = TestFacultyId
                },
                new UserTask
                {
                    CreationDate = DateTime.Now,
                    Task = "testtask2",
                    Status = "open",
                    EditDate = null,
                    Id = UserTaskIdForDelete,
                    UserId = UserAId,
                    FacultyId = TestFacultyId
                },
                new UserTask
                {
                    CreationDate = DateTime.Now,
                    Task = "testtask2",
                    Status = "open",
                    EditDate = null,
                    Id = UserTaskIdForUpdate,
                    UserId = UserBId,
                    FacultyId = TestFacultyId
                }
            );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(UdvAppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
