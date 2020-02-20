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

}


export {ValidationResult,ValidationError }
