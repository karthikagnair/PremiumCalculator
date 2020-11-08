import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PremiumCalculatorComponent } from './premium-calculator.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ReferenceDataService } from '../../services/reference-data.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TestcompComponent', () => {
  let component: PremiumCalculatorComponent;
  let fixture: ComponentFixture<PremiumCalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PremiumCalculatorComponent],
      imports: [FormsModule, BrowserModule, HttpClientTestingModule],
      providers: [ReferenceDataService]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PremiumCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  describe('Premium Calculator', function () {
    it('calculate premium', function () {
      component.age = 60;
      component.sumInsured = 10000;
      component._factor = 1.5;
      component.CalculatePremium();
      expect(component.insurancePreminum).toBe(10800);
    });
  });
});
