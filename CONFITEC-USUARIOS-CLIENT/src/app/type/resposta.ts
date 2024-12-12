import { Usuario } from "./usuario";

export interface ApiResposta {
    dados: Usuario[];
    mensagem: string;
    status: boolean;
}