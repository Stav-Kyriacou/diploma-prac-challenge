import { Component, Input, OnInit } from '@angular/core';
import { MainService, Owner, Pet, Procedure, Treatment } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  currentOwnerID: number = 1;
  allOwners: Owner[] = [];
  allPets: Pet[] = [];
  allProcedures: Procedure[] = [];
  allTreatments: Treatment[] = [];
  owners: Owner[] = [];
  pets: Pet[] = [];
  treatments: Treatment[] = [];

  constructor(private _mainService: MainService) { }

  ngOnInit(): void {
    this.fetchData();
  }

  onCreateOwner(result: any) {
    console.log(result);
    if (result.name === "" || result.surname === "" || result.phone === "" ||
      result.name == null || result.surname == null || result.phone == null) {
      alert("Fields cannot be empty!");
      return;
    }
    this._mainService.createOwner(result.name, result.surname, parseInt(result.phone)).subscribe(null, null, () => {
      this.fetchData();
    });
  }

  addTreatment(result: any) {
    console.log(result);
    
  }

  onChange(event: any) {
    let ownerID = parseInt(event);
    console.log(ownerID);

    this.owners = this.allOwners.filter(owner => owner.ownerID === ownerID);
    this.pets = this.allPets.filter(pet => pet.ownerID === ownerID);
    this.treatments = this.allTreatments.filter(treatment => treatment.ownerID === ownerID);
  }

  fetchData() {
    this._mainService.getAllOwners().subscribe(data => this.allOwners = data, null, () => {
      this.owners = this.allOwners.filter(owner => owner.ownerID === this.currentOwnerID);
    });
    this._mainService.getAllPets().subscribe(data => this.allPets = data, null, () => {
      this.pets = this.allPets.filter(pet => pet.ownerID === this.currentOwnerID);
    });
    this._mainService.getAllProcedures().subscribe(data => this.allProcedures = data);
    this._mainService.getAllTreatments().subscribe(data => this.allTreatments = data, null, () => {
      this.treatments = this.allTreatments.filter(treatment => treatment.ownerID === this.currentOwnerID);
    });
  }
}
