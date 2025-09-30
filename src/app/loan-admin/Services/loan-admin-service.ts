import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoanOfficer } from '../../Models/loan-officer';
import { LoanApplication } from '../../Models/loan-application';

@Injectable({
  providedIn: 'root'
})
export class LoanAdminService {
  private apiUrl = 'https://localhost:7147/api'; // replace with your API base URL

  constructor(private http: HttpClient) {}

  // Fetch all loan officers
  getLoanOfficers(): Observable<LoanOfficer[]> {
    return this.http.get<LoanOfficer[]>(`${this.apiUrl}/loanadmin/loanofficers`);
  }

  // Add a new loan officer
  addLoanOfficer(officer: LoanOfficer): Observable<LoanOfficer> {
    return this.http.post<LoanOfficer>(`${this.apiUrl}/loanadmin/loanofficers`, officer);
  }

  // Update a loan officer
  updateLoanOfficer(officerId: string, officer: LoanOfficer): Observable<LoanOfficer> {
    return this.http.put<LoanOfficer>(`${this.apiUrl}/loanadmin/loanofficers/${officerId}`, officer);
  }

  // Delete a loan officer
  deleteLoanOfficer(officerId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/loanadmin/loanofficers/${officerId}`);
  }

  // Fetch all loan applications
  getAllLoanApplications(): Observable<LoanApplication[]> {
    return this.http.get<LoanApplication[]>(`${this.apiUrl}/loanadmin/loanapplications`);
  }
}
