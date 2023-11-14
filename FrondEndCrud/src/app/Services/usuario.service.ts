import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Usuario } from '../Interface/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService 
{
  private endpoint:string =  environment.enPoint;
  private apiUrl:string = this.endpoint + "usuarios/";

  constructor(private http:HttpClient) { }

  getList():Observable<Usuario[]>
  {
    return this.http.get<Usuario[]>(`${this.apiUrl}lista`);
  }

  add(modelo:Usuario):Observable<Usuario>
  {
    return this.http.post<Usuario>(`${this.apiUrl}guardar`, modelo);
  }

  update(id:number,modelo:Usuario):Observable<Usuario>
  {
    return this.http.put<Usuario>(`${this.apiUrl}update/${id}`, modelo);
  }

  delete(id:number):Observable<void>
  {
    return this.http.delete<void>(`${this.apiUrl}delete/${id}`);
  }
}
