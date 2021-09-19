using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Profiles
{
    public class ProvasProfile : Profile
    {
        public ProvasProfile()
        {
            CreateMap<ProvasRequest, ProvasEntity>().ReverseMap();
            CreateMap<ProvasEntity, ProvasResponse>().ReverseMap();
            CreateMap<ProvasUpdateRequest, ProvasEntity>().ReverseMap();
        }
    }
}





