using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.Entities.BaseEntities
{
    public class BaseEntitiy
    {
        public BaseEntitiy()
        {
            this.CreateDate = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
