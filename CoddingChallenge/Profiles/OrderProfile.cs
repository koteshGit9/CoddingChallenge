using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;

namespace CoddingChallenge.Profiles
{
    public class OrderProfile:Profile
    {public OrderProfile() {


            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();


        }
    }
}
