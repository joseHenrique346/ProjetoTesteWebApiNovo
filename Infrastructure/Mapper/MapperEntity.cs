using AutoMapper;
using Domain.DTO.Entity;
using Infrastructure.Persistence.EFCore.Entity.Registration;

namespace Infrastructure.Mapper
{
    public class MapperEntity : Profile
    {
        public MapperEntity()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}