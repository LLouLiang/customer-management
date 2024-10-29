import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerListComponent } from './customer-list/customer-list.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },  // Redirect to login by default
  { path: 'login', component: LoginComponent },
  { path: 'add-customer', component: CustomerFormComponent },
  { path: 'customers', component: CustomerListComponent },
];
