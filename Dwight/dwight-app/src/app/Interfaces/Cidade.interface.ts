import { Estado } from './Estado.interface';

export interface Cidade
{
  CidadeId: number;
  Nome: string;
  EstadoId: number;
  Estado: Estado
}
