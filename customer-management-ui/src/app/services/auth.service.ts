import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap, catchError, map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5000/api/auth';  // Replace with your actual API endpoint
  private tokenKey = 'auth-token';

  constructor(private http: HttpClient, private router: Router) { 
    
  }

  login(username: string, password: string): any {
    // return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { username, password }).pipe(
    //   map(response => {
    //     // Store the token or any other logic
    //     localStorage.setItem('token', "");
    //     return true; // return true if login is successful
    //   }),
    //   catchError(() => {
    //     return of(false); // return false if login fails
    //   })
    // );
  }

  logout(): void {
      localStorage.removeItem(this.tokenKey);  // Clear token from storage
      this.router.navigate(['/login']);  // Redirect to login page
      console.log('User logged out successfully');  // Optional log for logout
  }

  isAuthenticated(): boolean {
      return !!localStorage.getItem(this.tokenKey);
  }

  getToken(): string | null {
      return localStorage.getItem(this.tokenKey);
  }
}
