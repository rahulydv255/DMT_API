using AutoMapper;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemitterData = DMT.Domain.DMT;

namespace DMT.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<QueryRimitterServiceContractResponse, QueryRemiterDomainRespoonse>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ErrorMessage, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.data, opt => opt.MapFrom(src => src.data));

            // Map from Data to Data
            CreateMap<DMT.ServiceIntegration.DataContract.Data, DMT.Domain.DMT.QueryRemiterDomainRespoonse.Data>()
                .ForMember(dest => dest.Fname, opt => opt.MapFrom(src => src.Fname))
                .ForMember(dest => dest.Lname, opt => opt.MapFrom(src => src.Lname))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Bank3Limit, opt => opt.MapFrom(src => src.Bank3Limit))
                .ForMember(dest => dest.Bank2Limit, opt => opt.MapFrom(src => src.Bank2Limit))
                .ForMember(dest => dest.Bank1Limit, opt => opt.MapFrom(src => src.Bank1Limit));
        }
    }

}


