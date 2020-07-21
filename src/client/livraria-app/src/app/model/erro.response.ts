export interface ErroLivro {
    Capa: string[];
    Autor: string[];
    Genero: string[];
    Titulo: string[];
}

export interface ErrosLivro {
    type: string;
    title: string;
    status: number;
    traceId: string;
    errors: ErroLivro;
}