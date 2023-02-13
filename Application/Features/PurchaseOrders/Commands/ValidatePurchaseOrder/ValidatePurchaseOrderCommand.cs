﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Commands.ValidatePurchaseOrder
{
    public class ValidatePurchaseOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; } = string.Empty;
        public string VendorEmail { get; set; } = string.Empty;
        public DateTime PlacedOn { get; set; }
        public DateTime DeliverOn { get; set; }
        public int Status { get; set; }
        public string DeliveryLocation { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string ItemId { get; set; } = default!;
        public int Total { get; set; }
        public string? PaymentTerms { get; set; }
    }
}
