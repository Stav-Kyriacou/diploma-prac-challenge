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
  createOwner(surname: string, firstname: string, phone: number): Observable<number> {
    const body = "";
    const params = new HttpParams()
      .append('surname', surname)
      .append('firstname', firstname)
      .append('phone', phone)
    return this._http.post<number>(this.baseUrl + '/create-owner', body, { 'params': params });
  }
  getAllProcedures(): Observable<Procedure[]> {
    return this._http.get<Procedure[]>(this.baseUrl + '/procedures');
  }
  getAllTreatments(): Observable<Treatment[]> {
    return this._http.get<Treatment[]>(this.baseUrl + '/treatments');
  }
}
export interface Pet {
  ownerID: number;
  petID: number;
  petName: string;
  type: string;
}
export interface Owner {
  ownerID: number;
  surname: string;
  firstname: string;
  phone: number;
}
export interface Procedure {
  procedureID: number;
  description: string;
  price: number;
}
export interface Treatment {
  ownerID: number;
  treatmentID: number;
  petID: number;
  procedureID: number;
  date: Date;
  notes: string;
  payment: number;
}
