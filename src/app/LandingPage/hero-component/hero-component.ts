import { Component } from '@angular/core';

@Component({
  selector: 'app-hero-component',
  imports: [],
  templateUrl: './hero-component.html',
  styleUrl: './hero-component.css'
})
export class HeroComponent {

  scrollToCalculator(): void {
    document.getElementById('calculator')?.scrollIntoView({ 
      behavior: 'smooth' 
    });
  }
}
