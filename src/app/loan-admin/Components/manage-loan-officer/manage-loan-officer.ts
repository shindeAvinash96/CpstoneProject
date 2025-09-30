import { Component, OnInit } from '@angular/core';
import { LoanAdminService } from '../../Services/loan-admin-service';
import { LoanOfficer } from '../../../Models/loan-officer';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-manage-loan-officers',
  templateUrl: './manage-loan-officer.component.html',
  styleUrls: ['./manage-loan-officer.component.css'],
    imports: [CommonModule, FormsModule]
})
export class ManageLoanOfficersComponent implements OnInit {

  loanOfficers: LoanOfficer[] = [];
  newOfficer: LoanOfficer = {
    officerId: '',
    branch: '',
    isActive: true,
    createdDate: new Date().toISOString(),
    firstName: '',
    lastName: '',
    userName: '',
    userRoleType: 'Officer',
    email: ''
  };
  successMessage = '';
  errorMessage = '';

  constructor(private adminService: LoanAdminService) { }

  ngOnInit(): void {
    this.loadLoanOfficers();
  }

  loadLoanOfficers() {
    this.adminService.getLoanOfficers().subscribe({
      next: (res: LoanOfficer[]) => this.loanOfficers = res,
      error: err => console.error(err)
    });
  }

  addOfficer() {
    this.adminService.addLoanOfficer(this.newOfficer).subscribe({
      next: () => {
        this.successMessage = 'Loan Officer added successfully';
        this.errorMessage = '';
        this.loadLoanOfficers();
      },
      error: err => {
        this.errorMessage = 'Failed to add loan officer';
        this.successMessage = '';
        console.error(err);
      }
    });
  }

  deleteOfficer(officerId: string) {
    this.adminService.deleteLoanOfficer(officerId).subscribe({
      next: () => this.loadLoanOfficers(),
      error: err => console.error(err)
    });
  }
}
