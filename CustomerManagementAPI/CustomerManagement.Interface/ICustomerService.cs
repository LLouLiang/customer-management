using System;
using CustomerManagement.DTO;
using CustomerManagement.Model;

namespace CustomerManagement.Interface
{
	public interface ICustomerService
	{
        Task<Customer> CreateCustomerAsync(CustomerDTO customerDto);
        Task<IEnumerable<CustomerDTO>> GetCustomersAsync();
    }
}

