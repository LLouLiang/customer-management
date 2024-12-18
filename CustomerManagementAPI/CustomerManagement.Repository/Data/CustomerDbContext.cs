﻿using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Repository.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options): base(options)
        {}

        public DbSet<Customer> Customers { get; set; }
    }
}

