using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Profiles
{
    public class DisciplinasProfile : Profile
    {
        public DisciplinasProfile()
        {
            CreateMap<DisciplinaRequest, DisciplinaEntity>().ReverseMap();
            CreateMap<DisciplinaEntity, DisciplinaResponse>().ReverseMap();
            CreateMap<DisciplinaUpdateRequest, DisciplinaEntity>().ReverseMap();
        }
    }
}





