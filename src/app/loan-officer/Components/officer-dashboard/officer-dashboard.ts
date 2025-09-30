import { Component, OnInit } from '@angular/core';
import { LoanOfficerService } from '../../Services/loan-officer-service';
import { LoanApplication } from '../../../Models/loan-application';
import { CommonModule, CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-officer-dashboard',
  templateUrl: './officer-dashboard.component.html',
  styleUrls: ['./officer-dashboard.component.css'],
  imports: [CommonModule, CurrencyPipe]
})
export class OfficerDashboardComponent implements OnInit {

  pendingLoans: LoanApplication[] = [];
  successMessage = '';
  errorMessage = '';

  constructor(private officerService: LoanOfficerService) { }

  ngOnInit(): void {
    this.loadPendingLoans();
  }

  loadPendingLoans() {
    this.officerService.getPendingLoans().subscribe({
      next: res => this.pendingLoans = res,
      error: err => console.error(err)
    });
  }

  approveLoan(id: number) {
    this.officerService.approveLoan(id).subscribe({
      next: () => {
        this.successMessage = 'Loan approved successfully';
        this.errorMessage = '';
        this.loadPendingLoans();
      },
      error: err => {
        this.errorMessage = 'Failed to approve loan';
        this.successMessage = '';
        console.error(err);
      }
    });
  }

  rejectLoan(id: number) {
    this.officerService.rejectLoan(id).subscribe({
      next: () => {
        this.successMessage = 'Loan rejected successfully';
        this.errorMessage = '';
        this.loadPendingLoans();
      },
      error: err => {
        this.errorMessage = 'Failed to reject loan';
        this.successMessage = '';
        console.error(err);
      }
    });
  }
}
