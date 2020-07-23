import { Usuario } from './usuario';
import { Livro } from './livro';

export interface EmprestimoLivro {
    usuarioId: number;
    usuario: Usuario;
    livroId: number;
    livro: Livro;
    dataDevolucao: Date;
    devolvido: boolean;
    id: number;
}