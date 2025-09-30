// src/app/customer/loan-application.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoanApplication } from '../../Models/loan-application';
import { LoanScheme } from '../../Models/loan-scheme';

@Injectable({
  providedIn: 'root'
})
export class LoanApplicationService {

  private baseUrl = 'https://localhost:7147/api/LoanApplications';

  constructor(private http: HttpClient) { }

  // Get all loan schemes
  getLoanSchemes(): Observable<LoanScheme[]> {
    return this.http.get<LoanScheme[]>(`${this.baseUrl}/schemes`);
  }

  // Apply for a new loan
  applyLoan(loan: LoanApplication): Observable<any> {
    return this.http.post(`${this.baseUrl}`, loan);
  }

  // Get loan applications for a specific customer
 // loan-application-service.ts
getCustomerLoanApplications(customerId: number): Observable<LoanApplication> {
  return this.http.get<LoanApplication>(
    `${this.baseUrl}/customers/${customerId}/loan-applications`
  );
}

}
