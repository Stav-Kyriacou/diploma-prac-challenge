import { Component, OnInit } from '@angular/core';
import { MainService, Owner, Pet, Procedure, Treatment } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  owners: Owner[] = [];
  pets: Pet[] = [];
  procedures: Procedure[] = [];
  treatments: Treatment[] = [];

  constructor(private _mainService: MainService) { }

  ngOnInit(): void {
    this._mainService.getAllOwners().subscribe(data => this.owners = data);
    this._mainService.getAllPets().subscribe(data => this.pets = data);
    this._mainService.getAllProcedures().subscribe(data => this.procedures = data);
    this._mainService.getAllTreatments().subscribe(data => this.treatments = data);
  }

}
