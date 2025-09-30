import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

interface Feature {
  icon: string;
  title: string;
  description: string;
}
@Component({
  selector: 'app-features-component',
  imports: [CommonModule],
  templateUrl: './features-component.html',
  styleUrl: './features-component.css'
})
export class FeaturesComponent {

  features: Feature[] = [
    {
      icon: '⚡',
      title: 'Instant Approvals',
      description: 'Automated loan approval process with real-time decision making'
    },
    {
      icon: '📊',
      title: 'Smart Analytics',
      description: 'Comprehensive reporting and analytics for better decision making'
    },
    {
      icon: '🔒',
      title: 'Bank-Level Security',
      description: 'Your data is protected with enterprise-grade security measures'
    },
    {
      icon: '🔄',
      title: 'Auto Payments',
      description: 'Set up automatic payments and never miss a due date'
    },
    {
      icon: '📱',
      title: 'Mobile First',
      description: 'Manage your loans on the go with our mobile-friendly platform'
    },
    {
      icon: '🌐',
      title: 'API Integration',
      description: 'Seamlessly integrate with your existing systems and workflows'
    }
  ];
}
