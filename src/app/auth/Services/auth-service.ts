import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { Customer } from '../../Models/customer';
import { UserRole } from '../../Models/customer';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7147/api'; 

  constructor(private http: HttpClient, private router: Router) {}

  // Login
  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Auth/login`, { email, password }).pipe(
      tap(res => {
        if (res.token) {
          localStorage.setItem('token', res.token);
          localStorage.setItem('userId', res.userId);
          localStorage.setItem('userRole', res.role); // must match backend
          localStorage.setItem('userEmail', email);
        }
      })
    );
  }

  // Register
 register(user: Customer): Observable<any> {
    return this.http.post(`${this.baseUrl}/Customers`, user);
  }
  // Logout
  logout(): void {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  // Helpers
  getToken(): string | null { return localStorage.getItem('token'); }
  getUserRole(): string | null { return localStorage.getItem('userRole'); }
  isLoggedIn(): boolean { return !!this.getToken(); }

  // Redirect user based on role
  redirectUserBasedOnRole(): string {
    const role = this.getUserRole();
    console.log('Redirecting userRole:', role);
    if (role === 'Customer') return '/customer-dashboard';
    if (role === 'LoanOfficer') return '/officer-dashboard';
    if (role === 'Admin') return '/admin-dashboard';
    return '/home';
  }

  // AuthService
getUserEmail(): string | null {
  return localStorage.getItem('userEmail');
}

}
