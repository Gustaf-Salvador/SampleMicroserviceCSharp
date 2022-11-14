using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using SampleMicroservice.Application.RequestEvent;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Services.Model;

namespace SampleMicroservice.Services.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "ListCustomer")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<FullCustomerDto>))]
        [Route("")]
        public async Task<IEnumerable<FullCustomerDto>> ListCustomer()
        {
            var listCustomerRequest = new ListCustomerRequestEvent();

            var response = await _mediator.Send(listCustomerRequest);

            return _mapper.Map<IEnumerable<Customer>, IEnumerable<FullCustomerDto>>(response, ctx => ctx.Items.Add("Map Address", false));
        }


        [HttpPost]
        [SwaggerOperation(OperationId = "CreateCustomer")]
        [SwaggerResponse(200, Type = typeof(FullCustomerDto))]
        [Route("")]
        public async Task<FullCustomerDto> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            var address = _mapper.Map<Address>(customerDto.Address);

            var createCustomerRequest = new CreateCustomerRequestEvent(
                customerDto.Name, customerDto.Birthdate, customerDto.Email, address);

            var response = await _mediator.Send(createCustomerRequest);

            return _mapper.Map<Customer, FullCustomerDto>(response, ctx => ctx.Items.Add("Map Address", true));
        }


        [HttpDelete]
        [SwaggerOperation(OperationId = "DeleteCustomer")]
        [SwaggerResponse(204, Type = typeof(IActionResult))]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute(Name = "id")] Guid id)
        {
            var deleteCustomerRequest = new DeleteCustomerRequestEvent(id);

            await _mediator.Publish(deleteCustomerRequest);

            return NoContent();
        }


        [HttpPatch]
        [SwaggerOperation(OperationId = "UpdateCustomer")]
        [SwaggerResponse(200, Type = typeof(FullCustomerDto))]
        [Route("{id}")]
        public async Task<FullCustomerDto> UpdateCustomer(
            [FromRoute(Name = "id")] Guid id,
            [FromBody] JsonPatchDocument<CustomerDto> customerPatchDto)
        {            
            var customerPatch = _mapper.Map<JsonPatchDocument<CustomerDto>, JsonPatchDocument<Customer>>(customerPatchDto);

            var updateCustomerRequest = new UpdateCustomerRequestEvent(id, customerPatch);

            var response = await _mediator.Send(updateCustomerRequest);

            return _mapper.Map<Customer, FullCustomerDto>(response, ctx => ctx.Items.Add("Map Address", true));
        }


        [HttpGet]
        [SwaggerOperation(OperationId = "GetCustomerById")]
        [SwaggerResponse(200, Type = typeof(FullCustomerDto))]
        [Route("{id}")]
        public async Task<FullCustomerDto> GetCustomerById([FromRoute(Name = "id")] Guid id)
        {
            var getCustomerRequest = new GetCustomerByIdRequestEvent(id);

            var response = await _mediator.Send(getCustomerRequest);

            return _mapper.Map<Customer, FullCustomerDto>(response, ctx => ctx.Items.Add("Map Address", true));
        }
    }
}