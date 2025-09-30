import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Repayment } from '../../Models/repayment';

@Injectable({ providedIn: 'root' })
export class RepaymentService {
  private baseUrl = 'https://localhost:7147/api/Repayments';

  constructor(private http: HttpClient) {}

  getCustomerRepayments(customerId: number): Observable<Repayment[]> {
    return this.http.get<Repayment[]>(`${this.baseUrl}/Repayments/${customerId}`);
  }
}
