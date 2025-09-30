import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/Services/auth-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar-component.component.html',
  styles : './navbar-component.component.css',
  imports: [CommonModule]
})
export class NavbarComponent implements OnInit {
  userEmail: string | null = '';

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.userEmail = this.authService.getUserEmail();
  }

  logout(): void {
    this.authService.logout();
  }
}
