using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvApp.Domain
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FacultyId { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
