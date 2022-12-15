using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(UdvAppDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
