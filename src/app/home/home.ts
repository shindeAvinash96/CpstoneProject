import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Router } from '@angular/router';

/**
 * A simple model for the application features to display on the home page.
 */
interface Feature {
  icon: string;
  title: string;
  description: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [],
  // This template content would normally be in a separate home-page.component.html file
  template: `
    <!-- Main Application Container -->
    <div class="min-h-screen bg-gray-50 flex flex-col items-center justify-center p-4">

      <!-- Gradient Background Overlay -->
      <div class="absolute inset-0 z-0 bg-gradient-to-br from-indigo-50 via-white to-sky-100 opacity-70"></div>

      <!-- Hero Section Card -->
      <div class="z-10 bg-white p-6 sm:p-10 md:p-14 rounded-2xl shadow-2xl max-w-5xl w-full mx-auto transform transition duration-500 hover:shadow-3xl">
        
        <header class="text-center mb-10">
          <h1 class="text-4xl sm:text-5xl font-extrabold text-indigo-700 leading-tight">
            Seamless Loan Management
          </h1>
          <p class="mt-4 text-xl text-gray-600 font-light">
            Your trusted platform for fast, transparent, and secure loan applications and tracking.
          </p>
        </header>

        <!-- Call to Action Buttons -->
        <div class="flex flex-col sm:flex-row justify-center gap-4 mb-12">
          
          <!-- Register Button -->
          <button (click)="goToRegister()" 
                  class="flex-1 max-w-xs sm:max-w-none px-8 py-3 bg-indigo-600 text-white text-lg font-semibold rounded-lg shadow-md transition duration-300 transform hover:scale-105 hover:bg-indigo-700 focus:outline-none focus:ring-4 focus:ring-indigo-300">
            Register Now
            <span class="ml-2" aria-hidden="true">→</span>
          </button>
          
          <!-- Login Button -->
          <button (click)="goToLogin()" 
                  class="flex-1 max-w-xs sm:max-w-none px-8 py-3 border border-indigo-600 text-indigo-600 text-lg font-semibold rounded-lg shadow-md transition duration-300 transform hover:scale-105 hover:bg-indigo-50 focus:outline-none focus:ring-4 focus:ring-indigo-200">
            Login
          </button>
        </div>

        <!-- Features Grid -->
        <div class="mt-12">
          <h2 class="text-3xl font-bold text-center text-gray-800 mb-8">Why Choose Us?</h2>
          <div class="grid grid-cols-1 md:grid-cols-3 gap-8">
            @for (feature of features; track feature.title) {
              <div class="flex flex-col items-center text-center p-6 bg-indigo-50 rounded-xl shadow-inner">
                <span class="text-4xl text-indigo-500 mb-4">{{ feature.icon }}</span>
                <h3 class="text-xl font-semibold text-gray-800 mb-2">{{ feature.title }}</h3>
                <p class="text-gray-600">{{ feature.description }}</p>
              </div>
            }
          </div>
        </div>
        
        <footer class="mt-12 text-center text-sm text-gray-400 border-t pt-6">
            &copy; 2024 Loan Management App. All rights reserved.
        </footer>
      </div>
    </div>
  `,
  // This style content would normally be in a separate home-page.component.css file
  styles: [`
    /* Custom style to make the shadow pop a bit more */
    .shadow-3xl {
      box-shadow: 0 25px 50px -12px rgba(99, 102, 241, 0.4);
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Home {
  // Static data for the features section
  features: Feature[] = [
    {
      icon: '⚡',
      title: 'Quick Application',
      description: 'Complete your loan application in minutes with our streamlined digital process.'
    },
    {
      icon: '📊',
      title: 'Transparent Tracking',
      description: 'View your application status and loan details in real-time on your dashboard.'
    },
    {
      icon: '🔒',
      title: 'Secure & Private',
      description: 'Your financial data is protected with state-of-the-art encryption standards.'
    }
  ];

  constructor(private router:Router) {}

  /**
   * Placeholder for the navigation logic to the registration page.
   * In a real application, you would use the Router service here:
   * this.router.navigate(['/register']);
   */
  goToRegister(): void {
    console.log('Navigating to Registration...');
    this.router.navigate(['/register'])
    // Add Angular Router logic here (e.g., this.router.navigate(['/register']))
  }

  /**
   * Placeholder for the navigation logic to the login page.
   * In a real application, you would use the Router service here:
   * this.router.navigate(['/login']);
   */
  goToLogin(): void {
    console.log('Navigating to Login...');
    this.router.navigate(['/login']);
    // Add Angular Router logic here (e.g., this.router.navigate(['/login']))
  }
}
