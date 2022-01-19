using CqrsTemplate.Core.Excepitons;
using CqrsTemplate.Core.Handlers.Commands;
using CqrsTemplate.Core.Handlers.Queries;
using CqrsTemplate.Data.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CqrsTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOrdersQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTO model)
        {
            try
            {
                var command = new CreateOrderCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }
    }
}
