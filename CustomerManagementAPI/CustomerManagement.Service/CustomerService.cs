using CustomerManagement.DTO;
using CustomerManagement.Interface;
using CustomerManagement.Interface.Repository;
using CustomerManagement.Model;

namespace CustomerManagement.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerDTO customerDto)
        {
            // Validate customer data
            if (string.IsNullOrEmpty(customerDto.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrEmpty(customerDto.LastName))
                throw new ArgumentException("Last name is required.");
            if (string.IsNullOrEmpty(customerDto.Email) || !IsValidEmail(customerDto.Email))
                throw new ArgumentException("Email is required.");

            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                MiddleName = customerDto.MiddleName,
                LastName = customerDto.LastName,
                Email = customerDto.Email
            };

            return await _customerRepository.CreateCustomerAsync(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return customers.Select(c => new CustomerDTO
            {
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                Email = c.Email
            });
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

