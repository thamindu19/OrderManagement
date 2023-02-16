using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Application.Features.PurchaseOrders.Queries.GetPurchaseOrderDetail;
using Application.Features.PurchaseOrders.Queries.GetPurchaseOrderList;
using Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<PurchaseOrder, PurchaseOrderListVm>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderDetailVm>().ReverseMap();
            
            CreateMap<Item, ItemDto>().ReverseMap(); ;
            CreateMap<Item, CreateItemDto>().ReverseMap(); ;

            CreateMap<PurchaseOrder, CreatePurchaseOrderCommand>().ReverseMap();
            CreateMap<PurchaseOrder, CreatePurchaseOrderDto>().ReverseMap();
        }
    }
}
