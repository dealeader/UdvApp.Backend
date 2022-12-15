using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Application.Faculties.Queries.GetFacultyList
{
    public class FacultyListVm
    {
        public IList<FacultyLookupDto> Faculties { get; set; }
    }
}
