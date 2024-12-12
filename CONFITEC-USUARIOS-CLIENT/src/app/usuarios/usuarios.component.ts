import { Component, inject, OnInit } from '@angular/core';
import { UsuariosService } from '../services/usuarios.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { Usuario } from '../type/usuario';
import { ApiResposta } from '../type/resposta';
import { AsyncPipe, DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuarios',
  standalone: true,
  imports: [AsyncPipe, DatePipe, CommonModule],
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class UsuariosComponent implements OnInit {
  usuarios$!:Observable<Usuario[]>
    
  usuarioService = inject(UsuariosService)

  ngOnInit(): void {
    this.usuarios$ = this.usuarioService.getUsuarios().pipe(
      map(resposta => resposta.dados)
    );
  }
}
