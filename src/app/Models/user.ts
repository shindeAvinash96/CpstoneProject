export interface User {
  userId?: number;
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  passwordHash?: string;
  userRoleType?: 'Admin' | 'Officer' | 'Customer';
}
