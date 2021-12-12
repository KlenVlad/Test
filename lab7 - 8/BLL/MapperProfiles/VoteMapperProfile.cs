using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.MapperProfiles
{
    public class VoteMapperProfile : Profile
    {
        public VoteMapperProfile()
        {
            CreateMap<Vote, VoteDTO>()
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.VoteStats.Percentage))
                .ReverseMap();
        }
    }
}
