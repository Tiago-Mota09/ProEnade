using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Profiles
{
    public class ProfessorQuestoesProfile : Profile
    {
        public ProfessorQuestoesProfile()
        {
            CreateMap<DisciplinaQuestoesRequest, DisciplinaQuestoesEntity>().ReverseMap();
            CreateMap<DisciplinaQuestoesEntity, DisciplinaQuestoesResponse>().ReverseMap();
            CreateMap<DisciplinaQuestoesUpdateRequest, DisciplinaQuestoesEntity>().ReverseMap();
        }
    }
}





