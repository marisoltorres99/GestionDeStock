using AutoMapper;
using GestionDeStock.DTOs;
using GestionDeStock.Models;

namespace GestionDeStock.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductInsertDTO, Product>();
            CreateMap<Product, ProductDTO>().ForMember(dto => dto.Id, m => m.MapFrom(p => p.Id));
            CreateMap<ProductUpdateDTO, Product>();
        }
    }
}