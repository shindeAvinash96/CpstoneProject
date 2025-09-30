import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar-component/navbar-component';
import { SidebarComponent } from './sidebar-component/sidebar-component';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './LandingPage/header-component/header-component';
import { FooterComponent } from './LandingPage/footer-component/footer-component';
import { HeroComponent } from './LandingPage/hero-component/hero-component';


import { FeaturesComponent } from './LandingPage/features-component/features-component';
import { CustomerDashboardComponent } from './customer/Components/customer-dashboard/customer-dashboard.component';
import { OfficerDashboardComponent } from './loan-officer/Components/officer-dashboard/officer-dashboard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,SidebarComponent, CommonModule,HeaderComponent,FooterComponent,HeroComponent,FeaturesComponent,CustomerDashboardComponent,OfficerDashboardComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isAuthPage=false;
  title = 'Loan Management System';

  constructor(private router: Router) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isAuthPage = ['/login', '/register'].includes(event.urlAfterRedirects);
      }
    });
  }
}
