using AutoMapper;

namespace RecipeBook.Aplication.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() { RequestToDomain(); }

        private void RequestToDomain()
        {
            CreateMap<Communication.Requests.RequestRegisterUserJson, Domain.Entities.User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
