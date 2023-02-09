using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Queries.GetPurchaseOrderDetail
{
    public class GetPurchaseOrderDetailQuery : IRequest<PurchaseOrderDetailVm>
    {
        public Guid Id { get; set; }
    }
}
