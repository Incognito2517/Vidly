using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly_New.Dtos;

namespace Vidly_New.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()).ForMember(m => m.Timestamp, opt => opt.Ignore());

        }
    }
}