import { Component } from '@angular/core';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrl: './customer-form.component.css'
})
export class CustomerFormComponent {
  firstName: string = '';
  middleName: string = '';
  lastName: string = '';
  email: string = '';
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private customerService: CustomerService) {}

  addCustomer() {
    const customer = { firstName: this.firstName, middleName: this.middleName, lastName: this.lastName, email: this.email };

    this.customerService.addCustomer(customer).subscribe(
      () => {
          this.successMessage = 'Customer added successfully';
          this.errorMessage = '';
          this.resetForm();
      },
      () => {
          this.errorMessage = 'Failed to add customer';
          this.successMessage = '';
      }
    );        
  }

  resetForm() {
    this.firstName = '';
    this.middleName = '';
    this.lastName = '';
    this.email = '';
  }
}
