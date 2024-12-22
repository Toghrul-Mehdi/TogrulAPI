using AutoMapper;
using TogrulAPI.DTOs.Language;

namespace TogrulAPI.Profiles.Language
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto,Entities.Language>();
        }
    }
}
