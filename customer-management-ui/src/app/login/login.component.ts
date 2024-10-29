import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage: string = '';

  constructor(private authService: AuthService){

  }
  login() {
    this.authService.login(this.username, this.password).subscribe(
      (response) => {
        if (!response) {
          this.errorMessage = 'Invalid username or password';
        }
      },
      (error) => {
        this.errorMessage = 'An error occurred during login';
      }
    );
  }
}
