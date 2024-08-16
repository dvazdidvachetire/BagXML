using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.Models;

namespace BagXML
{
    public sealed class Profiler : Profile
    {
        public Profiler()
        {
            CreateMap<Product, ProductEntity>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(s => decimal.Parse(s.Price.Replace('.', ','))))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(s => int.Parse(s.Quantity)));
            CreateMap<Product, Product>();
            CreateMap<ProductOrder, ProductOrderEntity>();
            CreateMap<User, UserEntity>();
        }
    }
}
