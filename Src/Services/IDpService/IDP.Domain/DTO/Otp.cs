using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.DTO
{
    public class Otp
    {
        public required string UserName { get; set; }
        public required int Otpcode {  get; set; }
        public bool IsUse { get; set; }
    }
}
