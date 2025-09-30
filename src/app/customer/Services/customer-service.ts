// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';
// import { Customer } from '../../Models/customer';
// import { LoanApplication } from '../../Models/loan-application';

// @Injectable({ providedIn: 'root' })
// export class CustomerService {
//   private apiUrl = 'https://localhost:7147/api/Customers';

//   constructor(private http: HttpClient) {}

//   getAll(): Observable<Customer[]> {
//     return this.http.get<Customer[]>(this.apiUrl);
//   }

//   getById(id: number): Observable<Customer> {
//     return this.http.get<Customer>(`${this.apiUrl}/${id}`);
//   }

//   add(customer: Customer): Observable<Customer> {
//     return this.http.post<Customer>(this.apiUrl, customer);
//   }

//     getCustomerLoanApplications(customerId: number): Observable<LoanApplication[]> {
//     return this.http.get<LoanApplication[]>(
//       `${this.apiUrl}/LoanApplications/GetByCustomer/${customerId}`
//     );

//   }
// }

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../../Models/customer';
import { LoanApplication } from '../../Models/loan-application';

@Injectable({ providedIn: 'root' })
export class CustomerService {
  private apiUrl = 'https://localhost:7147/api/Customers'; // Base API URL for Customers

  constructor(private http: HttpClient) {}

  // Get all customers
  getAll(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }

  // Get a customer by ID
  getById(id: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.apiUrl}/${id}`);
  }

  // Add a new customer
  add(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, customer);
  }

  // Get loan applications for a specific customer by their ID
  getCustomerLoanApplications(customerId: number): Observable<LoanApplication[]> {
    const loanApiUrl = `https://localhost:7147/api/LoanApplications/GetByCustomer/${customerId}`;
    return this.http.get<LoanApplication[]>(loanApiUrl);
  }
}
