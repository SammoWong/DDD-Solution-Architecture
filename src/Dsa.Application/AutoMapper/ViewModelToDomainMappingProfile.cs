using AutoMapper;
using Dsa.Application.ViewModels;
using Dsa.Application.ViewModels.Orders;
using Dsa.Domain.Models;

namespace Dsa.Application.AutoMapper
{
    /// <summary>
    /// 视图模型 -> 领域模式的映射
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderDto, Order>();
        }
    }
}
