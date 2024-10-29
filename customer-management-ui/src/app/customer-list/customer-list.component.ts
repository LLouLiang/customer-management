import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer.service';

interface Customer {
  fullName: string;
  email: string;
}

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})
export class CustomerListComponent implements OnInit{
  customers: Customer[] = [];

  constructor(private customerService: CustomerService) {}

  ngOnInit() {
      this.fetchCustomers();
  }

  fetchCustomers() {
    this.customerService.getCustomers().subscribe(
      (response) => {
          // this.customers = response;
      },
      (error) => {
          console.error('Failed to fetch customers', error);
      }
    );
  }
}
