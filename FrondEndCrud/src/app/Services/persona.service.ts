import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Persona } from '../Interface/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService 
{

  private endpoint:string =  environment.enPoint;
  private apiUrl:string = this.endpoint + "personas/";

  constructor(private http:HttpClient) { }

  getList():Observable<Persona[]>
  {
    return this.http.get<Persona[]>(`${this.apiUrl}lista`);
  }

  add(modelo:Persona):Observable<Persona>
  {
    return this.http.post<Persona>(`${this.apiUrl}guardar`, modelo);
  }

  update(id:number,modelo:Persona):Observable<Persona>
  {
    return this.http.put<Persona>(`${this.apiUrl}update/${id}`, modelo);
  }

  delete(id:number):Observable<void>
  {
    return this.http.delete<void>(`${this.apiUrl}delete/${id}`);
  }
}
