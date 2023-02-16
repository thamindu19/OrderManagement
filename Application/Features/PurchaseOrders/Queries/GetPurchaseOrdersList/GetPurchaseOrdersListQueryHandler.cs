using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Queries.GetPurchaseOrderList
{
    public class GetPurchaseOrdersListQueryHandler : IRequestHandler<GetPurchaseOrdersListQuery, List<PurchaseOrderListVm>>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public GetPurchaseOrdersListQueryHandler(IMapper mapper, IPurchaseOrderRepository purchaseOrderRepository)
        {
            _mapper = mapper;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<List<PurchaseOrderListVm>> Handle(GetPurchaseOrdersListQuery request, CancellationToken cancellationToken)
        {
            var @allPurchaseOrders = (await _purchaseOrderRepository.ListAllWithItemsAsync()).OrderBy(p => p.PlacedOn);
            return _mapper.Map<List<PurchaseOrderListVm>>(allPurchaseOrders);
        }
    }
}
