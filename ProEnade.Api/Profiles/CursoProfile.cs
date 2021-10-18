using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Profiles
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<CursoRequest, CursoEntity>().ReverseMap();
            CreateMap<CursoEntity, CursoResponse>().ReverseMap();
            CreateMap<CursoUpdateRequest, CursoEntity>().ReverseMap();
        }
    }
}
