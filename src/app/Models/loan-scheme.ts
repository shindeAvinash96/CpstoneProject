export interface LoanScheme {
  loanSchemeId: number;
  schemeName: string;
  interestRate: number;
  maxAmount: number;
  minAmount?: number;   // optional
  description?: string; // optional
  tenureInMonths?: number; // optional
}
