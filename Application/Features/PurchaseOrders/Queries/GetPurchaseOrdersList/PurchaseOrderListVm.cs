using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Queries.GetPurchaseOrderList
{
    public class PurchaseOrderListVm
    {
        public Guid Id { get; set; }
        public string Vendor { get; set; } = string.Empty;
        public DateTime PlacedOn { get; set; }
        public DateTime DeliverOn { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<Item>? Items { get; set; }
        public int Total { get; set; }
    }
}
