
export interface Errors {
    LivroId: string[];
    UsuarioId: string[];
    DataDevolucao: string[];
}

export class ErroEmprestimo {
    errors: Errors;
    type: string;
    title: string;
    status: number;
    traceId: string;
}