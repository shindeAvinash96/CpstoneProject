import { Component } from '@angular/core';
import { HeaderComponent } from '../LandingPage/header-component/header-component';
import { FooterComponent } from '../LandingPage/footer-component/footer-component';
import { HeroComponent } from '../LandingPage/hero-component/hero-component';
import { FeaturesComponent } from '../LandingPage/features-component/features-component';

@Component({
  selector: 'app-dashboard',
  imports: [HeaderComponent,FooterComponent,HeroComponent,FeaturesComponent],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {

}
