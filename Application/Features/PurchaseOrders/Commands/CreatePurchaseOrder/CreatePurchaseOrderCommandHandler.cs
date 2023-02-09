﻿using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, CreatePurchaseOrderCommandResponse>
    {
        private readonly IAsyncRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public CreatePurchaseOrderCommandHandler(IMapper mapper, IAsyncRepository<PurchaseOrder> purchaseOrderRepository)
        {
            _mapper = mapper;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<CreatePurchaseOrderCommandResponse> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var createPurchaseOrderCommandResponse = new CreatePurchaseOrderCommandResponse();

            var validator = new CreatePurchaseOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPurchaseOrderCommandResponse.Success = false;
                createPurchaseOrderCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPurchaseOrderCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createPurchaseOrderCommandResponse.Success)
            {
                var purchaseOrder = new PurchaseOrder() { Vendor = request.Vendor };
                purchaseOrder = await _purchaseOrderRepository.AddAsync(purchaseOrder);
                createPurchaseOrderCommandResponse.PurchaseOrder = _mapper.Map<CreatePurchaseOrderDto>(purchaseOrder);
            }

            return createPurchaseOrderCommandResponse;
        }
    }
}
