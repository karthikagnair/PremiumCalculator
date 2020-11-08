import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PremiumCalculatorComponent } from './premium-calculator/premium-calculator.component';
import { ReferenceDataService } from '../services/reference-data.service';

const appRoutes: Routes = [
  { path: 'PremiumCalculator', component: PremiumCalculatorComponent },
  { path: '', redirectTo: '/PremiumCalculator', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    PremiumCalculatorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [ReferenceDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
