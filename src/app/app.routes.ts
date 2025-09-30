import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/Components/login/login.component';
import { RegisterComponent } from './auth/Components/register/register.component';
import { CustomerDashboardComponent } from './customer/Components/customer-dashboard/customer-dashboard.component';
import { AdminDashboardComponent } from './loan-admin/Components/admin-dashboard/admin-dashboard';
import { OfficerDashboardComponent } from './loan-officer/Components/officer-dashboard/officer-dashboard';
import { AuthGuard } from './auth-guard-guard';
import { Home } from './home/home';
import { Dashboard } from './dashboard/dashboard';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },

  // Auth
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {path:'dashboard', component:Dashboard},

  // Dashboards
  { path: 'customer-dashboard', component: CustomerDashboardComponent, canActivate: [AuthGuard], data: { role: 'Customer' } },
  { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard], data: { role: 'Admin' } },
  { path: 'officer-dashboard', component: OfficerDashboardComponent, canActivate: [AuthGuard], data: { role: 'LoanOfficer' } },

  // Home
  { path: 'home', component: Home },

  // Fallback
  { path: '**', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
