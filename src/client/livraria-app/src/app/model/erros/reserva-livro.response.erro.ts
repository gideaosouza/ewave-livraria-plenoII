
export interface Errors {
    LivroId: string[];
    UsuarioId: string[];
    DataResgate: string[];
}

export interface ErroReservaLivro {
    errors: Errors;
    type: string;
    title: string;
    status: number;
    traceId: string;
}



