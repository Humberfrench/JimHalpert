import { Cidade } from './Cidade.interface';
import { TipoDeCliente } from './TipoDeCliente.interface';
import { TipoDePessoa } from './TipoDePessoa.interface';

export interface Cliente
{
  Nome: string;
  RazaoSocial: string;
  Documento: string;
  TipoDeClienteId: number;
  TipoDePessoaId: number;
  tipoDeCliente: TipoDeCliente;
  tipoDePessoa: TipoDePessoa;
  Telefone: string;
  Contato: string;
  Email: string;
  InscricaoEstadual: string;
  CadastroMunicipal: string;
  Endereco: string;
  Numero: string;
  Complemento: string;
  Bairro: string;
  Cep: string;
  CidadeId: number;
  cidade: Cidade;
  DataCriacao: Date;
  DataAlteracao: Date;
}
