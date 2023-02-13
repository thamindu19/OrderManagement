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
        private readonly IAsyncRepository<PurchaseOrder> _purchaseorderRepository;
        private readonly IAsyncRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetPurchaseOrderDetailQueryHandler(IMapper mapper, IAsyncRepository<PurchaseOrder> purchaseorderRepository, IAsyncRepository<Item> orderRepository)
        {
            _mapper = mapper;
            _purchaseorderRepository = purchaseorderRepository;
            _itemRepository = orderRepository;
        }

        public async Task<PurchaseOrderDetailVm> Handle(GetPurchaseOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var @purchaseOrder = await _purchaseorderRepository.GetByIdAsync(request.Id);
            var purchaseOrderDetailDto = _mapper.Map<PurchaseOrderDetailVm>(@purchaseOrder);
/*
            var Item = await _itemRepository.GetByIdAsync(@purchaseOrder.Id);

            if (Item == null)
            {
                throw new NotFoundException(nameof(PurchaseOrder), request.Id);
            }
            purchaseOrderDetailDto.Item = _mapper.Map<ItemDto>(Item);*/

            return purchaseOrderDetailDto;
        }
    }
}
