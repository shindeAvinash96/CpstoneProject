import { Repayment } from "./repayment";
import { LoanScheme } from "./loan-scheme";


export interface LoanApproved {
  loanApprovedId?: number;
  loanApplicationId: number;
  totalAmount: number;
  noOfPayments: number;
  installment: number;
  startDate: string;
  repayments: Repayment[];
  loanScheme?:LoanScheme;
}
