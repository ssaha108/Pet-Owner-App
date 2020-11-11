# Pet-Owner-App

The project demonstrates consuming HttpClient API in latest .NET 5.0 Web API project, and then using it as service to further re-expose as [baseurl]/api/petowner/ for a client application (Angular App) to consume some processed data.

The endpoint API The [baseurl]/api/petowner/catsbygender (GET request) returns Cat names categorised by their owner gender.

I have used Postman to test the API.

## Demo Task Specification

http://agl-developer-test.azurewebsites.net/

## API consumed 

http://agl-developer-test.azurewebsites.net/people.json

## New API for client application

[baseurl]/api/petowner/catsbygender

The above returns Cat names sorted and categorised by their owner gender

## Getting Started

To run the project you will need:

```
.NET 5.0 SDK/Runtime
Angular CLI version: 10.1.7
```

## Prerequisites MUST

Before you run the Pet-Owner-App client project, please ensure to update the http API base URL to match the API:

Open /Pet-Owner-App/src/app/_services/pet-owner.service.ts and update the URL (and/or localhost port number) based on .NET application server base URL (line number 8). Below is the code snippet:

```
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
```
