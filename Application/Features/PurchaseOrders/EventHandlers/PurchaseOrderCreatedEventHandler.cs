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
using System.Reflection;

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

            var messageBody = $"A new purchase order created for  {notification.PurchaseOrder.Vendor}.<br><br>" +
                $"Company: OrderManagement Project <br>" +
                $"Reference ID: {notification.PurchaseOrder.Id} <br><br>" +
                $"Placed On: {notification.PurchaseOrder.PlacedOn} <br>" +
                $"Deliver Before: {notification.PurchaseOrder.DeliverOn} <br>" +
                $"Delivery Location: {notification.PurchaseOrder.DeliveryLocation} <br>" +
                $"Notes: {notification.PurchaseOrder.Notes} <br><br> ";

            if (notification.PurchaseOrder.Items != null)
            {
                messageBody += "Items: <br>";
                int c = 0;
                foreach (var item in notification.PurchaseOrder.Items)
                {
                    c++;
                    messageBody += $"Item {c} -> ";
                    messageBody += $"{item.Name} <br> \t Description: {item.Description} <br> \t Quantity: {item.Quantity} <br> \t Price: {item.Price} <br>";
                }
                messageBody += "<br>";
            }

            messageBody += $"Total: {notification.PurchaseOrder.Total} <br>" +
                $"Payment Terms: {notification.PurchaseOrder.PaymentTerms}";

            var email = new Email() { To = $"{notification.PurchaseOrder.VendorEmail}", Body = messageBody, Subject = "New purchase order from OM Project" };

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
