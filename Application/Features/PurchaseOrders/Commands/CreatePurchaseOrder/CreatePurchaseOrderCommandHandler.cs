using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Models.Mail;
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
        private readonly IEmailService _emailService;

        public CreatePurchaseOrderCommandHandler(IMapper mapper, IAsyncRepository<PurchaseOrder> purchaseOrderRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _purchaseOrderRepository = purchaseOrderRepository;
            _mapper = mapper;
            _emailService = emailService;
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
                var purchaseOrder = new PurchaseOrder() {
                    Vendor = request.Vendor,
                    VendorEmail = request.VendorEmail,
                    PlacedOn = request.PlacedOn,
                    DeliverOn = request.DeliverOn,
                    Status = request.Status,
                    DeliveryLocation = request.DeliveryLocation,
                    Notes = request.Notes,
                    Total = request.Total,
                    ItemId = request.ItemId,
                    PaymentTerms = request.PaymentTerms,
    };
                purchaseOrder = await _purchaseOrderRepository.AddAsync(purchaseOrder);
                createPurchaseOrderCommandResponse.PurchaseOrder = _mapper.Map<CreatePurchaseOrderDto>(purchaseOrder);
            }

            var email = new Email() { To = "thamindub@itx360.com", Body = $"A new purchase order was created: {request}", Subject = "New purchase order" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
            }

            return createPurchaseOrderCommandResponse;
        }
    }
}
