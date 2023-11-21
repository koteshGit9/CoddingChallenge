using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;
namespace CoddingChallenge.Profiles
{
    public class UserProfile:Profile

    {


        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
