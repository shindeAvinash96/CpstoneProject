import { Customer } from './customer';
import { LoanOfficer } from './loan-officer';
import { LoanScheme } from './loan-scheme';

export interface LoanApplication {
  loanApplicationId: number;
  loanType: string;
  loanAmount: number;
  status: 'Pending' | 'Approved' | 'Rejected';
  createdAt: Date;
  customerId: number;
  customer?: Customer;
  loanOfficerId?: number;
  loanOfficer?: LoanOfficer;
  loanSchemeId: number;
  loanScheme?: LoanScheme;
}
