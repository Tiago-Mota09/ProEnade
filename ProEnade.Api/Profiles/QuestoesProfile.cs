using AutoMapper;
using ProEnade.API.Data.Entities;
using ProEnade.API.Domain.Models.Request;
using ProEnade.API.Domain.Models.Response;

namespace ProEnade.API.Profiles
{
    public class QuestoesProfile : Profile
    {
        public QuestoesProfile()
        {
            CreateMap<QuestoesRequest, QuestoesEntity>().ReverseMap();
            CreateMap<QuestoesEntity, QuestoesResponse>().ReverseMap();
            CreateMap<QuestoesUpdateRequest, QuestoesEntity>().ReverseMap();
        }
    }
}





