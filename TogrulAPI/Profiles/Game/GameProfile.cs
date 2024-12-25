using AutoMapper;
using TogrulAPI.DTOs.Game;

namespace TogrulAPI.Profiles.Game
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto, Entities.Game>();
        }
    }
}
