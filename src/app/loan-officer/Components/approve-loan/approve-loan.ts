import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoanOfficerService } from '../../Services/loan-officer-service';
import { LoanApplication } from '../../../Models/loan-application';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { LoanScheme } from '../../../Models/loan-scheme';

@Component({
  selector: 'app-approve-loan',
  templateUrl: './approve-loan.component.html',
  styleUrls: ['./approve-loan.component.css'],
   imports: [CommonModule, CurrencyPipe]
})
export class ApproveLoan implements OnInit {

  loan: LoanApplication | null = null;
  successMessage = '';
  errorMessage = '';
  schemes:LoanScheme[]=[];

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private officerService: LoanOfficerService
  ) { }

  ngOnInit(): void {
    const loanId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadLoan(loanId);
  }

  loadLoan(id: number) {
    this.officerService.getPendingLoans().subscribe({
      next: res => {
        this.loan = res.find(l => l.loanApplicationId === id) || null;
        if (!this.loan) this.errorMessage = 'Loan not found or already processed';
      },
      error: err => console.error(err)
    });
  }

  approveLoan() {
    if (!this.loan) return;
    this.officerService.approveLoan(this.loan.loanApplicationId).subscribe({
      next: () => {
        this.successMessage = 'Loan approved successfully!';
        this.errorMessage = '';
        setTimeout(() => this.router.navigate(['/officer-dashboard']), 1500);
      },
      error: err => {
        this.errorMessage = 'Failed to approve loan';
        this.successMessage = '';
        console.error(err);
      }
    });
  }

  rejectLoan() {
    if (!this.loan) return;
    this.officerService.rejectLoan(this.loan.loanApplicationId).subscribe({
      next: () => {
        this.successMessage = 'Loan rejected successfully!';
        this.errorMessage = '';
        setTimeout(() => this.router.navigate(['/officer-dashboard']), 1500);
      },
      error: err => {
        this.errorMessage = 'Failed to reject loan';
        this.successMessage = '';
        console.error(err);
      }
    });
  }
}
