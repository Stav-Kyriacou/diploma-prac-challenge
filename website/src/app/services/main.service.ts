import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  readonly baseUrl: string = "https://localhost:5001";

  constructor(private _http: HttpClient) { }

  getAllPets(): Observable<Pet[]> {
    return this._http.get<Pet[]>(this.baseUrl + '/pets');
  }
  getAllOwners(): Observable<Owner[]> {
    return this._http.get<Owner[]>(this.baseUrl + '/owners');
  }
  getAllProcedures(): Observable<Procedure[]> {
    return this._http.get<Procedure[]>(this.baseUrl + '/procedures');
  }

}
export interface Pet {
  OwnerID: number;
  PetID: number;
  PetName: string;
  Type: string;
}
export interface Owner {
  OwnerID: number;
  Surname: string;
  FirstName: string;
  Phone: number;
}
export interface Procedure {
  ProcedureID: number;
  Description: string;
  Price: number;
}
export interface Treatment {
  OwnerID: number;
  TreatmentID: number;
  PetID: number;
  Date: Date;
  Notes: string;
  Payment: number;
}
