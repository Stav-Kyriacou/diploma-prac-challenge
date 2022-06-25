import { Component, OnInit } from '@angular/core';
import { MainService } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(private _mainService: MainService) { }

  ngOnInit(): void {
    this._mainService.getAllOwners().subscribe(data => {
      console.log(data);
    });
    this._mainService.getAllPets().subscribe(data => {
      console.log(data);
    });
    this._mainService.getAllProcedures().subscribe(data => {
      console.log(data);
    });
  }

}
