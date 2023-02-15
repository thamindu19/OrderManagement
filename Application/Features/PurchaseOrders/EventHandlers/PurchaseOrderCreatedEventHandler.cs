using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;
using Application.Models.Mail;
using Application.Contracts.Infrastructure;

namespace Application.Features.PurchaseOrders.EventHandlers
{
    public class PurchaseOrderCreatedEventHandler : INotificationHandler<PurchaseOrderCreatedEvent>
    {
        private readonly ILogger<PurchaseOrderCreatedEventHandler> _logger;
        private readonly IEmailService _emailService;

        public PurchaseOrderCreatedEventHandler(ILogger<PurchaseOrderCreatedEventHandler> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(PurchaseOrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Vendor: ", notification.PurchaseOrder.VendorEmail);

            var email = new Email() { To = "thamindub19@gmail.com", Body = $"A new purchase order was created: {notification.PurchaseOrder.Id}", Subject = "New purchase order" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
            }
        }
    }
}
