﻿using AutoMapper;
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
using Application.Features.PurchaseOrders.Commands.ValidatePurchaseOrder;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<PurchaseOrder, PurchaseOrderListVm>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderDetailVm>().ReverseMap();
            CreateMap<Item, ItemDto>();
             
            CreateMap<PurchaseOrder, CreatePurchaseOrderCommand>().ReverseMap();
            CreateMap<PurchaseOrder, CreatePurchaseOrderDto>().ReverseMap();
            CreateMap<PurchaseOrder, ValidatePurchaseOrderCommand>().ReverseMap();
        }
    }
}
