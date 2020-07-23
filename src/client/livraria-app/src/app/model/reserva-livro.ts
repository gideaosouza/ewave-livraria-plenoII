import { Usuario } from './usuario';
import { Livro } from './livro';

export interface ReservaLivro {
    usuarioId: number;
    usuario: Usuario;
    livroId: number;
    livro: Livro;
    dataResgate: Date;
    id: number;
}
