using AutoMapper;
using Dsa.Application.ViewModels;
using Dsa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Application.AutoMapper
{
    /// <summary>
    /// 领域模型 -> 视图模型的映射
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
