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

namespace Application.Features.PurchaseOrders.Commands.ValidatePurchaseOrder
{
    public class ValidatePurchaseOrderCommandHandler : IRequestHandler<ValidatePurchaseOrderCommand>
    {
        private readonly IAsyncRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public ValidatePurchaseOrderCommandHandler(IMapper mapper, IAsyncRepository<PurchaseOrder> purchaseOrderRepository)
        {
            _mapper = mapper;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<Unit> Handle(ValidatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {

            var purchaseOrderToValidate = await _purchaseOrderRepository.GetByIdAsync(request.Id);
            if (purchaseOrderToValidate == null)
            {
                throw new NotFoundException(nameof(PurchaseOrder), request.Id);
            }

            var validator = new ValidatePurchaseOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, purchaseOrderToValidate, typeof(ValidatePurchaseOrderCommand), typeof(PurchaseOrder));

            await _purchaseOrderRepository.UpdateAsync(purchaseOrderToValidate);

            return Unit.Value;
        }
    }
}
