using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Models;
using Microsoft.AspNetCore.Http;
using Customers.Application.Customers.CRUD.ViewModels;
using Customers.Application.Customers.CRUD.Operations;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/customers")]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Creates the customer
        /// </summary>
        /// <response code="201">Success</response>
        /// <response code="409">Conflict</response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<long>> CreateCustomerAsync([FromBody] CreateCustomerDto createCustomerDto)
        {
            var command = _mapper.Map<CreateCustomerCommand>(createCustomerDto);
            var customerId = await Mediator.Send(command);
            return Ok(customerId);
        }

        /// <summary>
        /// Gets the customer by id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerInfoVm>> GetCustomerAsync([FromRoute] long id)
        {
            var query = new GetCustomerInfoQuery(id);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(updateCustomerDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the customer by id
        /// </summary>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCustomerAsync(long id)
        {
            var command = new DeleteCustomerCommand(id);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}