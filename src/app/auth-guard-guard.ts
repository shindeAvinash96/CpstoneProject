import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth/Services/auth-service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
      return false;
    }

    const expectedRole = route.data['role'];
    const userRole = this.authService.getUserRole();
    console.log('Guard check:', { expectedRole, userRole });

    if (!userRole || (expectedRole && userRole !== expectedRole)) {
      this.router.navigate(['/login']); // redirect unauthorized
      return false;
    }

    return true;
  }
}
