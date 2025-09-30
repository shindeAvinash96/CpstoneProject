import { Component, OnInit } from '@angular/core';
import { RepaymentService } from '../../Services/repayment-service';
import { Repayment } from '../../../Models/repayment';
import { CommonModule, CurrencyPipe, DatePipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-repayment-list',
  templateUrl: './repayment-list.component.html',
  styleUrls: ['./repayment-list.component.css'],
  imports:[CommonModule,CurrencyPipe,DatePipe,NgClass]
})
export class RepaymentListComponent implements OnInit {
  repayments: Repayment[] = [];

  constructor(private repaymentService: RepaymentService) {}

  ngOnInit(): void {
    const customerId = Number(localStorage.getItem('userId'));
    this.repaymentService.getCustomerRepayments(customerId).subscribe({
      next: (res: Repayment[]) => this.repayments = res,
      error: err => console.error(err)
    });
  }
}
