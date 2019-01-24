using AutoMapper;
using NermeenVidly.DTOs;
using NermeenVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NermeenVidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO,Customer>();
        }
    }
}