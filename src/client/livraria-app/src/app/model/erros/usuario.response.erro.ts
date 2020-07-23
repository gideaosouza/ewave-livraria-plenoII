
    export interface Errors {
        CPF: string[];
        Nome: string[];
        Email: string[];
        Telefone: string[];
    }

    export interface ErroUsuario {
        errors: Errors;
        type: string;
        title: string;
        status: number;
        traceId: string;
    }