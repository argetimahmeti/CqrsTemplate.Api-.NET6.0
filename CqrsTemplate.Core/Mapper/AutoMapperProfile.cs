using AutoMapper;
using CqrsTemplate.Data.Data.Entities;
using CqrsTemplate.Data.DTO;

namespace CqrsTemplate.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<Item, ItemDTO>();
        }
    }
}
