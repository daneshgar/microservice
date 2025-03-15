using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IDp.Application.Command.Auth;
using IDP.Domain.Entities;

namespace IDp.Application.Hellper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthCommand,User>().ReverseMap();
            
        }
    }
}
