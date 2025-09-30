import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/Services/auth-service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  standalone:true,
  templateUrl: './sidebar-component.component.html',
   imports: [CommonModule, RouterLink]
})
export class SidebarComponent implements OnInit {
  role: string | null= localStorage.getItem('userRole'); // <- Fix

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.role = this.authService.getUserRole();
  }
}
