using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommandValidator : AbstractValidator<CreatePurchaseOrderCommand>
    {
        public CreatePurchaseOrderCommandValidator() {
            RuleFor(p => p.DeliveryLocation).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.DeliverOn).NotEmpty().WithMessage("{PropertyName} is required.").Null().GreaterThan(DateTime.Now);
            RuleFor(p => p.Total).NotEmpty().WithMessage("{PropertyName} is required.").GreaterThan(0);
        }
    }
}
