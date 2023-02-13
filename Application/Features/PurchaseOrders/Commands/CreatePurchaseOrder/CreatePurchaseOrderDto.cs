using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder
{
    public class CreatePurchaseOrderDto
    {
        public Guid Id { get; set; }
        public string Vendor {get; set; } = string.Empty;
    }
}
