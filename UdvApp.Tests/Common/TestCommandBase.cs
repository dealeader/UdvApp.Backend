using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Persistence;

namespace UdvApp.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly UdvAppDbContext Context;

        public TestCommandBase()
        {
            Context = UdvAppContextFactory.Create();
        }

        public void Dispose()
        {
            UdvAppContextFactory.Destroy(Context);
        }
    }
}
