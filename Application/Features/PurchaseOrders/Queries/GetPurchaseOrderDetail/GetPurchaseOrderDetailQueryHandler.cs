using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Queries.GetPurchaseOrderDetail
{
    public class GetPurchaseOrderDetailQueryHandler : IRequestHandler<GetPurchaseOrderDetailQuery, PurchaseOrderDetailVm>
    {
        private readonly IPurchaseOrderRepository _purchaseorderRepository;
        private readonly IMapper _mapper;

        public GetPurchaseOrderDetailQueryHandler(IMapper mapper, IPurchaseOrderRepository purchaseorderRepository)
        {
            _mapper = mapper;
            _purchaseorderRepository = purchaseorderRepository;
        }

        public async Task<PurchaseOrderDetailVm> Handle(GetPurchaseOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var @purchaseOrder = await _purchaseorderRepository.GetByIdWithItemsAsync(request.Id);
            return _mapper.Map<PurchaseOrderDetailVm>(@purchaseOrder);
        }
    }
}
