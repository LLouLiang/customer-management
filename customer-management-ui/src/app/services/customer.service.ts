import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Customer {
    firstName: string;
    middleName?: string;
    lastName: string;
    email: string;
}

@Injectable({
    providedIn: 'root'
})
export class CustomerService {
    private apiUrl = 'http://localhost:5000/api/customers';  // Replace with your actual API endpoint

    constructor(private http: HttpClient) {}

    addCustomer(customer: Customer): any {
        return this.http.post<Customer>(this.apiUrl, customer);
    }

    getCustomers(): any {
        return this.http.get<Customer[]>(this.apiUrl);
    }
}