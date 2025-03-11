using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.DTO
{
    public class Otp
    {

        public  string UserName { get; set; }
        public  string Otpcode {  get; set; }
        public int UserId { get; set; }
        public bool IsUse { get; set; }
    }
}
