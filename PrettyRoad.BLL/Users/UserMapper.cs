using AutoMapper;
using PrettyRoad.BLL.Interface.Users;
using PrettyRoad.DAL.Entities;

namespace PrettyRoad.BLL.Users;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserInfoDetails>();
        CreateMap<User, UserAuthenticateDetails>();
    }
}