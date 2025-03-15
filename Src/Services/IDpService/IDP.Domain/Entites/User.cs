using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities.BaseEntities;

namespace IDP.Domain.Entities
{
    public class User : BaseEntitiy
    {
        public  string FullName { get; set; }
        public string Email { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }
        public  string Salt { get; set; }
        public required string MobilNumber { get; set; }
    }
}
