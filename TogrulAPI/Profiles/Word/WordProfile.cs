using AutoMapper;
using TogrulAPI.DTOs.Word;

namespace TogrulAPI.Profiles.Word
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            /* CreateMap<WordCreateDto, Entities.Word>();            

             CreateMap<WordUpdateDto,Entities.Word>();
             CreateMap<Entities.Word,WordGetDto>()
                .ForMember(l => l.BannedWords, d => d.MapFrom(t => t.BannedWords));*/
        }
    }
}
