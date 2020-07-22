export class ErroLivro {
    Capa: string[];
    Autor: string[];
    Genero: string[];
    Titulo: string[];
}

export class ErrosLivro {
    type: string;
    title: string;
    status: number;
    traceId: string;
    errors: ErroLivro;
}