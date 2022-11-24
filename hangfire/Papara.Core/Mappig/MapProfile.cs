using AutoMapper;
using Papara.Core.Dtos;
using Papara.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Core.Mappig
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
