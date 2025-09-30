import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth-service';
import { User } from '../../../Models/user';
import { Customer } from '../../../Models/customer';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, FormsModule]
})
export class RegisterComponent {
  user: Customer= {
    firstName: '',
    lastName: '',
    userName: '',
     email: '',
    passwordHash: '',
    aadharId:'',
    panId:'',
    contactNumber:'',
    dateOfBirth:'',
    city:''

  };

  error: string='';

  constructor(private auth: AuthService, private router: Router) {}

register() {
  if (!this.user.email || !this.user.passwordHash || !this.user.contactNumber) {
    this.error = 'Please fill all required fields';
    return;
  }

  // Hardcode role before submission
  this.user.userRoleType = 'Customer';

  // Make sure AadharId/PanId/DateOfBirth are correct format
  const payload = {
    ...this.user,
    dateOfBirth: this.user.dateOfBirth || '1990-01-01', // fallback
    aadharId: this.user.aadharId || '123456789012', // must be 12 chars
    panId: this.user.panId || 'ABCDE1234F',         // must be 10 chars
    contactNumber: this.user.contactNumber
  };

  console.log('Payload to send:', payload); // debug

  this.auth.register(payload).subscribe({
    next: () => this.router.navigate(['/login']),
    error: (err) => {
      console.error('Registration error', err);
      this.error = 'Registration failed. Please check your input.';
      alert(this.error);
    }
  });
}

}
