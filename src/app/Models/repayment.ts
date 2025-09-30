import { LoanApproved } from "./loan-approved";

export interface Repayment {
  repaymentId?: number;
  installmentNumber: number;
  amount: number;
  dueDate: string;
  status: 'Pending' | 'Paid';
  loanApproved:LoanApproved;
}
