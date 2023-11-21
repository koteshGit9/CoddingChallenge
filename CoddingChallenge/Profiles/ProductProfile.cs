using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;

namespace CoddingChallenge.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile() {

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
