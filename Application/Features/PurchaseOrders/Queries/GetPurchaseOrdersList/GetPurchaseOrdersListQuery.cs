using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Queries.GetPurchaseOrderList
{
    public class GetPurchaseOrdersListQuery : IRequest<List<PurchaseOrderListVm>>
    {
    }
}
