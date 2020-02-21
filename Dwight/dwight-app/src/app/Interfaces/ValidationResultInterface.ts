interface ValidationResult
{
  StatusCode: number;
  Erros: ValidationError[];
  IsValid: boolean;
  Messagem: string;
  CodigoMessagem: number
  Retorno: any;
  ProblemaDeInfraestrutura: boolean;
  Warning: boolean;
}

interface ValidationError
{
  Codigo: number
  Messagem: string;
  Erro: boolean;
}


export { ValidationResult,ValidationError }
