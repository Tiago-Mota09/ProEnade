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
            CreateMap<ProfessorQuestoesRequest, ProfessorQuestoesEntity>().ReverseMap();
            CreateMap<ProfessorQuestoesEntity, ProfessorQuestoesResponse>().ReverseMap();
            CreateMap<ProfessorQuestoesUpdateRequest, ProfessorQuestoesEntity>().ReverseMap();
        }
    }
}





