import { Estado } from './Estado.interface';

export interface Cidade
{
  cidadeId: number;
  nome: string;
  estadoId: number;
  cidade: Cidade;
}
