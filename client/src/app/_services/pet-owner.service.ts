import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PetOwnerService {
  baseUrl = 'https://localhost:5001/api/petowner/';

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  GetCatsByOwnerGender(){
  return this.http.get(this.baseUrl + 'catsbygender');
  }
}
