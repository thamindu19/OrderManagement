using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class PurchaseOrderCreatedEvent : BaseEvent
    {
        public PurchaseOrderCreatedEvent(PurchaseOrder purchaseOrder)
        {
            PurchaseOrder = purchaseOrder;
        }

        public PurchaseOrder PurchaseOrder { get; }
    }
}
