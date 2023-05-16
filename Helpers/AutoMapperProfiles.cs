using AutoMapper;
using atteducation.Dtos;
using atteducation.api.Models;

namespace salescontrol.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<RolsToListDto, Rol>();
            // CreateMap<User, UserUpdateDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Rol, RolsToListDto>();
            CreateMap<UserForDetailedDto, User>();

        }
    }
}