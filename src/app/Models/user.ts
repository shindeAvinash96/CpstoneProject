export type UserRole = 'Admin' | 'Customer' | 'Officer';

export interface User {
  userId?: number;
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  passwordHash?: string;
  userRoleType?: UserRole;
}
