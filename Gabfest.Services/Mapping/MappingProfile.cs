using AutoMapper;
using Gabfest.Data;

namespace Gabfest.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserCreateModel>().ReverseMap();
    }
}
