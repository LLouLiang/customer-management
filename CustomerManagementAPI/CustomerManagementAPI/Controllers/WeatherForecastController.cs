using CustomerManagement.DTO;
using CustomerManagement.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(
        ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("/createCustomer")]
    public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerDTO customerDto)
    {
        try
        {
            var customer = await _customerService.CreateCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customer);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("/getCustomers")]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
    {
        try
        {
            var customers = await _customerService.GetCustomersAsync();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("/auth")]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetToken()
    {
        return true
    }
}

