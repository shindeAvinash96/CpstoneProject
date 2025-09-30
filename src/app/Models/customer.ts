// src/app/Models/customer.ts
import { User, UserRole } from './user';

// Export UserRole immediately (so other files can import it from customer if needed)
export type { UserRole };

export interface Customer extends User {
  aadharId: string;        // 12 chars
  panId: string;           // 10 chars
  contactNumber: string;   // Phone number
  dateOfBirth: string;     // ISO string for backend
  city: string;
}
