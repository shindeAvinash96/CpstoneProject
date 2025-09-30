import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth-service';
import { Customer,UserRole } from '../../../Models/customer';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, FormsModule]
})
export class RegisterComponent {

  user: Customer = {
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    passwordHash: '',
    userRoleType: 'Customer' as UserRole,
    aadharId: '',
    panId: '',
    contactNumber: '',
    dateOfBirth: '',
    city: ''
  };

  error: string = '';

  constructor(private auth: AuthService, private router: Router) {}

  register() {

    // Basic field validation
    if (!this.user.firstName || !this.user.lastName || !this.user.email ||
        !this.user.userName || !this.user.passwordHash || !this.user.contactNumber ||
        !this.user.aadharId || !this.user.panId || !this.user.dateOfBirth || !this.user.city) {
      this.error = 'Please fill all required fields';
      return;
    }

    // Validate Aadhar & PAN length
    if (this.user.aadharId.length !== 12) {
      this.error = 'Aadhar ID must be 12 digits';
      return;
    }

    if (this.user.panId.length !== 10) {
      this.error = 'PAN ID must be 10 characters';
      return;
    }

    // Ensure role
    this.user.userRoleType = 'Customer';

    // Prepare payload for backend
    const payload: Customer = {
      ...this.user,
      dateOfBirth: new Date(this.user.dateOfBirth).toISOString()
    };

    console.log('Payload to send:', payload);

    this.auth.register(payload).subscribe({
      next: () => {
        this.error = '';
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Registration error', err);
        this.error = 'Registration failed. Please check your input.';
        alert(this.error);
      }
    });
  }
}
