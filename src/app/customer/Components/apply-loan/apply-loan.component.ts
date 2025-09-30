import { Component, OnInit } from '@angular/core';
import { LoanApplicationService } from '../../Services/loan-application-service';
import { LoanScheme } from '../../../Models/loan-scheme';
import { LoanApplication } from '../../../Models/loan-application';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-apply-loan',
  templateUrl: './apply-loan.component.html',
  styleUrls: ['./apply-loan.component.css'],
    imports: [CommonModule, FormsModule]
})
export class ApplyLoan implements OnInit {
  loan: LoanApplication = {
    loanApplicationId: 0,
    loanType: '',
    loanAmount: 0,
    status: 'Pending',
    createdAt: new Date(),
    customerId: Number(localStorage.getItem('userId')),
    loanSchemeId: 0
  };

  schemes: LoanScheme[] = [];
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private loanAppService: LoanApplicationService) {}

  ngOnInit(): void {
    this.loadLoanSchemes();
  }

  loadLoanSchemes() {
    this.loanAppService.getLoanSchemes().subscribe({
      next: (res: LoanScheme[]) => this.schemes = res,
      error: err => console.error(err)
    });
  }

  applyLoan() {
    this.loanAppService.applyLoan(this.loan).subscribe({
      next: () => {
        this.successMessage = 'Loan application submitted successfully!';
        this.errorMessage = '';
        this.loan.loanAmount = 0;
        this.loan.loanType = '';
      },
      error: err => {
        this.errorMessage = 'Failed to apply loan';
        this.successMessage = '';
        console.error(err);
      }
    });
  }
}
