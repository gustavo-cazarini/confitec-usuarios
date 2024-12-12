import { Routes } from '@angular/router';
import { UsuariosComponent } from './usuarios/usuarios.component'
import { UsuarioFormComponent } from './usuarios/usuario-form/usuario-form.component'

export const routes: Routes = [
    {
        path:'usuarios',
        component:UsuariosComponent
    },
    {
        path:'usuarios/:id',
        component:UsuarioFormComponent
    }
];
