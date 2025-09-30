import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  imports: [CommonModule, FormsModule]
})
export class LoginComponent {
  email = '';
  password = '';
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.email, this.password).subscribe({
      next: () => {
        const redirectUrl = this.authService.redirectUserBasedOnRole();
        this.router.navigate([redirectUrl]);
      },
      error: (err) => {
        this.errorMessage = 'Login failed. Please check credentials.';
        console.log(err);
      }
    });
  }
}
