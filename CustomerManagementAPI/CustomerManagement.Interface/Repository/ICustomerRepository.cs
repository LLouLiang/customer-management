using System;
using CustomerManagement.Model;

namespace CustomerManagement.Interface.Repository
{
	public interface ICustomerRepository
	{
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}

