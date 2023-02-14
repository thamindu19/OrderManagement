using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOrders.Commands.ValidatePurchaseOrder
{
    public class ValidatePurchaseOrderCommandValidator : AbstractValidator<ValidatePurchaseOrderCommand>
    {
        public ValidatePurchaseOrderCommandValidator()
        {
            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
