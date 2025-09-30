import { User } from "./user";

export interface Customer extends User {
  aadharId: string;
  panId: string;
  contactNumber: string;
  dateOfBirth: string;
  city: string;
}
