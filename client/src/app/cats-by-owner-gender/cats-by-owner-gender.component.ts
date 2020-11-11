import { Component, OnInit } from '@angular/core';
import { PetOwnerService } from '../_services/pet-owner.service';

@Component({
  selector: 'app-cats-by-owner-gender',
  templateUrl: './cats-by-owner-gender.component.html',
  styleUrls: ['./cats-by-owner-gender.component.css']
})
export class CatsByOwnerGenderComponent implements OnInit {
  peoples: any;
  constructor(public petOwnerService: PetOwnerService) { }

  ngOnInit(): void {
    this.getCatsByOwnerGender();
  }

  // tslint:disable-next-line: typedef
  getCatsByOwnerGender() {
    this.petOwnerService.GetCatsByOwnerGender().subscribe(response => {
      this.peoples = response;
    }, error => {
      console.log(error);
    });
  }

}
