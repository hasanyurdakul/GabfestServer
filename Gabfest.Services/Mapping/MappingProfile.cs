using AutoMapper;
using Gabfest.Data;

namespace Gabfest.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User Mappings
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        //Message Mappings
        CreateMap<Message, MessageModel>().ReverseMap();
        CreateMap<Message, MessageCreateModel>().ReverseMap();
        CreateMap<Message, MessageUpdateModel>().ReverseMap();
        //Group Mappings
        CreateMap<Group, GroupModel>().ReverseMap();
        CreateMap<Group, GroupCreateModel>().ReverseMap();
        CreateMap<Group, GroupUpdateModel>().ReverseMap();
    }
}
