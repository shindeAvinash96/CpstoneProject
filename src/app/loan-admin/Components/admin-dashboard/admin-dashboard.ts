import { Component, OnInit } from '@angular/core';
import { LoanAdminService } from '../../Services/loan-admin-service';
import { LoanApplication } from '../../../Models/loan-application';
import { CommonModule, CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  imports:[CurrencyPipe,CommonModule]
})
export class AdminDashboardComponent implements OnInit {

  recentLoans: LoanApplication[] = [];
  totalLoans: number = 0;
  pendingLoans: number = 0;

  constructor(private adminService: LoanAdminService) { }

  ngOnInit(): void {
    this.loadLoans();
  }

  loadLoans() {
    this.adminService.getAllLoanApplications().subscribe({
      next: (res: LoanApplication[]) => {
        this.recentLoans = res.slice(-5); // last 5 loans
        this.totalLoans = res.length;
        this.pendingLoans = res.filter(l => l.status === 'Pending').length;
      },
      error: err => console.error(err)
    });
  }
}
