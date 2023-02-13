using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommandResponse : BaseResponse
    {
        public CreatePurchaseOrderCommandResponse() {
            
        }

        public CreatePurchaseOrderDto PurchaseOrder { get; set; } = default!;
    }
}
