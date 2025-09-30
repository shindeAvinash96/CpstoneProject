import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoanApplication } from '../../Models/loan-application';
import { LoanApproved } from '../../Models/loan-approved';
import { LoanScheme } from '../../Models/loan-scheme';

@Injectable({
  providedIn: 'root'
})
export class LoanOfficerService {
  private apiUrl = 'https://localhost:7147/api'; // replace with your API URL
  private schemeURL='https://localhost:7147/api/LoanSchemes';

  constructor(private http: HttpClient) { }

  // Get all pending loan applications
  getPendingLoans(): Observable<LoanApplication[]> {
    return this.http.get<LoanApplication[]>(`${this.apiUrl}/loanofficer/pendingloans`);
  }

  // Approve a loan
  approveLoan(loanApplicationId: number): Observable<LoanApproved> {
    return this.http.post<LoanApproved>(`${this.apiUrl}/loanofficer/approve/${loanApplicationId}`, {});
  }

  // Reject a loan
  rejectLoan(loanApplicationId: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/loanofficer/reject/${loanApplicationId}`, {});
  }

  getSchemes():Observable<LoanScheme[]>{

    return this.http.get<LoanScheme[]>(this.schemeURL);
  }
}
