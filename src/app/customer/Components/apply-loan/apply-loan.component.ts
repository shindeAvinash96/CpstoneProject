import { Component, OnInit, ViewChild } from '@angular/core';
import { LoanApplicationService } from '../../Services/loan-application-service';
import { LoanScheme } from '../../../Models/loan-scheme';
import { LoanApplication } from '../../../Models/loan-application';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common'; // Needed for *ngIf, *ngFor

// Mark the component as standalone: true
@Component({
  selector: 'app-apply-loan',
  templateUrl: './apply-loan.component.html',
  styleUrls: ['./apply-loan.component.css'],
  // In modern Angular (v17+), imports are directly defined on the component
  standalone: true, 
  imports: [CommonModule, FormsModule] 
})
export class ApplyLoan implements OnInit {
  // Use ViewChild to access the form element in the template
  @ViewChild('loanForm') loanForm!: NgForm;

  loan: LoanApplication = {
    loanApplicationId: 0,
    loanType: '',
    loanAmount: 0,
    status: 'Pending',
    createdAt: new Date(),
    // Get customer ID from local storage
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
      error: err => {
        this.errorMessage = 'Failed to load loan schemes.';
        console.error(err);
      }
    });
  }

  applyLoan() {
    // Basic client-side validation check
    if (!this.loanForm.valid) {
      this.errorMessage = 'Please fill out all required fields correctly.';
      return;
    }
    
    this.loanAppService.applyLoan(this.loan).subscribe({
      next: () => {
        this.successMessage = 'Loan application submitted successfully!';
        this.errorMessage = '';
        
        // Reset the form in the UI and the data model
        this.loanForm.resetForm({
          loanApplicationId: 0,
          loanType: '',
          loanAmount: 0,
          status: 'Pending',
          createdAt: new Date(),
          customerId: Number(localStorage.getItem('userId')),
          loanSchemeId: 0 // Reset scheme ID to the default option
        });
      },
      error: err => {
        this.errorMessage = 'Failed to apply loan. Please try again.';
        this.successMessage = '';
        console.error(err);
      }
    });
  }
}