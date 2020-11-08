import { Component, OnInit } from '@angular/core';
import { ReferenceData } from '../../models/reference-data.model';
import { OccupationRating } from '../../models/occupation-rating.model';
import { OccupationRatingFactor } from '../../models/occupation-rating-factor.model';
import { ReferenceDataService } from '../../services/reference-data.service';
import { finalize } from 'rxjs/operators/finalize';

@Component({
  selector: 'app-premium-calculator',
  templateUrl: './premium-calculator.component.html',
  styleUrls: ['./premium-calculator.component.css']
})
export class PremiumCalculatorComponent implements OnInit {

  _referenceData: ReferenceData[];
  _occupationRatings: OccupationRating[];
  _ratingFactors: OccupationRatingFactor[];
  occupationId: number;
  insurancePreminum: number = 0;
  sumInsured: number;
  age: number;
  _factor: number = 0;
  isFormValid: boolean = false;

  constructor(private referenceDataService: ReferenceDataService) {
  }

  ngOnInit() {
    this.referenceDataService.GetReferenceData().pipe(finalize(() => {
    })).subscribe(refData => {
      this._referenceData = refData;
      this._occupationRatings = this._referenceData[0].occupationRating;
      this._ratingFactors = this._referenceData[0].ratingFactor;
    });
  }

  OccupationChanged(event: any) {
    this.occupationId = event.target.value;
    this.CalculatePremium();
  }

  CalculatePremium() {
    if (this.sumInsured > 0 && this.age > 0) {
      var ratingId = 0;
      for (let i = 0; i <= this._occupationRatings.length; i++) {
        if (this._occupationRatings[i].occupationId == this.occupationId) {
          ratingId = this._occupationRatings[i].ratingId;
          break;
        }
      }

      for (let i = 0; i <= this._ratingFactors.length; i++) {
        if (this._ratingFactors[i].ratingId == ratingId) {
          this._factor = this._ratingFactors[i].factor;
          break;
        }
      }
      this.insurancePreminum = (this.sumInsured * this._factor * this.age) / 1000 * 12;
    }
  }
}
