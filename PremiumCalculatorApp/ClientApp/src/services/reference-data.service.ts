import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReferenceData } from '../models/reference-data.model';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class ReferenceDataService {

  readonly _baseUrl;
  _result: ReferenceData[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  GetReferenceData(): Observable<ReferenceData[]> {
    return this.http.get(this._baseUrl + 'api/RefData/GetReferenceData').pipe(
      map((res: any) => {
        return res;
      }));
  }
}
