using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseOrder : BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; } = string.Empty;
        public string VendorEmail { get; set; } = string.Empty;
        public DateTime PlacedOn { get; set; }
        public DateTime DeliverOn { get; set; }
        public string Status { get;set; } = string.Empty;
        public string DeliveryLocation { get; set; } = string.Empty;
        public string? Notes { get;set; }
        public ICollection<Item>? Items { get; set; }
        public int Total { get;set; }
        public string? PaymentTerms { get; set; }
    }
}
