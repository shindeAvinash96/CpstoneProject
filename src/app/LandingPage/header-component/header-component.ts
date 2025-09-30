import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header-component',
  imports: [],
  templateUrl: './header-component.html',
  styleUrl: './header-component.css'
})
export class HeaderComponent {

  constructor(private router:Router){}

  isMenuOpen = false;

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
}

  goToRegister(): void {
    console.log('Navigating to Registration...');
    this.router.navigate(['/register'])
    // Add Angular Router logic here (e.g., this.router.navigate(['/register']))
  }

  goToLogin(): void {
    console.log('Navigating to Login...');
    this.router.navigate(['/login'])
    // Add Angular Router logic here (e.g., this.router.navigate(['/register']))
  }
}
