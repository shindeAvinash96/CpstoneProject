// import { Component, OnInit } from '@angular/core';
// import { LoanApplicationService } from '../../Services/loan-application-service';
// import { LoanApplication } from '../../../Models/loan-application';
// import { CommonModule, CurrencyPipe, DatePipe, NgClass } from '@angular/common';

// @Component({
//   selector: 'app-customer-dashboard',
//   templateUrl: './customer-dashboard.component.html',
//   styleUrls: ['./customer-dashboard.component.css'],
//     imports: [CommonModule, CurrencyPipe, DatePipe, NgClass]
// })
// export class CustomerDashboardComponent implements OnInit {
//   loanApplications: LoanApplication[] = [];

//   constructor(private loanAppService: LoanApplicationService) {}

//   ngOnInit(): void {
//     this.loadLoanApplications();
//   }

//  loadLoanApplications() {
//   const customerId = Number(localStorage.getItem('userId'));
//   if (!customerId) {
//     console.error("Customer ID missing in localStorage");
//     return;
//   }
// this.loanAppService.getCustomerLoanApplications(customerId).subscribe({
//   next: (res: LoanApplication[]) => {
//     console.log("API Response:", res);
//     this.loanApplications = res; // now types match
//     console.log("Loan applications after assign:", this.loanApplications);
//   },
//   error: err => console.error("API error:", err)
// });



// }

// }


import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { LoanApplication } from '../../../Models/loan-application';
import { CommonModule, CurrencyPipe, DatePipe, NgClass } from '@angular/common';
import { CustomerService } from '../../Services/customer-service';
@Component({
  selector: 'app-customer-dashboard',
  templateUrl: './customer-dashboard.component.html',
  styleUrls: ['./customer-dashboard.component.css'],
  imports: [CommonModule, CurrencyPipe, DatePipe, NgClass]
})
export class CustomerDashboardComponent implements OnInit {
  loanApplications: LoanApplication[] = [];

  constructor(
    private customerService: CustomerService, // Inject the CustomerService
    private cdRef: ChangeDetectorRef // Inject ChangeDetectorRef for manual change detection
  ) {}

  ngOnInit(): void {
    this.loadLoanApplications();
  }

  loadLoanApplications(): void {
    const customerId = Number(localStorage.getItem('userId')); // Retrieve the customer ID from localStorage
    if (!customerId) {
      console.error("Customer ID missing in localStorage");
      return;
    }

    // Call the service method to get loan applications for the given customer
    this.customerService.getCustomerLoanApplications(customerId).subscribe({
      next: (res: LoanApplication[]) => {
        console.log("API Response:", res);
        this.loanApplications = res; // Assign the response data to loanApplications
        console.log("Loan applications after assign:", this.loanApplications);

        // Trigger change detection if necessary
        this.cdRef.detectChanges();
      },
      error: (err) => alert("You Dont Have Any Loan Applications"), // Handle any errors
    });
  }
}
