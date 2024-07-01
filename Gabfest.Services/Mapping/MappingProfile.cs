using AutoMapper;
using Gabfest.Data;

namespace Gabfest.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
    }
}
