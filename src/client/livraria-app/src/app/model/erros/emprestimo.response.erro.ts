
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



//////////////////////Erros de validação com data

export interface AttemptedValue {
    usuarioId: number;
    usuario?: any;
    livroId: number;
    livro?: any;
    dataDevolucao: Date;
    devolvido: boolean;
    id: number;
    habilitado: boolean;
    dataCadastramento: Date;
}

export interface PropertyValue {
    usuarioId: number;
    usuario?: any;
    livroId: number;
    livro?: any;
    dataDevolucao: Date;
    devolvido: boolean;
    id: number;
    habilitado: boolean;
    dataCadastramento: Date;
}

export interface FormattedMessagePlaceholderValues {
    PropertyName?: any;
    PropertyValue: PropertyValue;
}

export interface Erro1 {
    propertyName: string;
    errorMessage: string;
    attemptedValue: AttemptedValue;
    customState?: any;
    severity: number;
    errorCode: string;
    formattedMessageArguments: any[];
    formattedMessagePlaceholderValues: FormattedMessagePlaceholderValues;
}

export interface Erro2 {
    erro: Erro1[]
}