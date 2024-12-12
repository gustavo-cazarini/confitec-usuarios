import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Usuario} from "../type/usuario";
import { Observable } from 'rxjs';
import { ApiResposta } from '../type/resposta';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http:HttpClient) { }

  getUsuarios = ():Observable<ApiResposta> => this.http.get<ApiResposta>("https://localhost:7101/api/Usuario/GetUsuarios")
}
