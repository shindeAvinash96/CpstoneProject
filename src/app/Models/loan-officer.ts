import { User } from "./user";

export interface LoanOfficer extends User {
  officerId: string;
  branch: string;
  isActive: boolean;
  createdDate: string;
}
