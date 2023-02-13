using Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder;
using Application.Features.PurchaseOrders.Commands.ValidatePurchaseOrder;
using Application.Features.PurchaseOrders.Queries.GetPurchaseOrderDetail;
using Application.Features.PurchaseOrders.Queries.GetPurchaseOrderList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : Controller
    {
        private readonly IMediator _mediator;

        public PurchaseOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPurchaseOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PurchaseOrderListVm>>> GetAllPurchaseOrders()
        {
            var dtos = await _mediator.Send(new GetPurchaseOrdersListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPurchaseOrderById")]
        public async Task<ActionResult<PurchaseOrderDetailVm>> GetPurchaseOrderById(Guid id)
        {
            var getPurchaseOrderDetailQuery = new GetPurchaseOrderDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getPurchaseOrderDetailQuery));
        }

        [HttpPost(Name = "AddPurchaseOrder")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePurchaseOrderCommand createPurchaseOrderCommand)
        {
            var id = await _mediator.Send(createPurchaseOrderCommand);
            return Ok(id);
        }

        [HttpPut(Name = "ValidatePurchaseOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Validate([FromBody] ValidatePurchaseOrderCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }
    }
}
