using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Profiles
{
    public class ProfessoresProfile : Profile
    {
        public ProfessoresProfile()
        {
            CreateMap<ProfessorRequest, ProfessorEntity>().ReverseMap();
            CreateMap<ProfessorEntity, ProfessorResponse>().ReverseMap();
            CreateMap<ProfessorUpdateRequest, ProfessorEntity>().ReverseMap();
        }
    }
}





