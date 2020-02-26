
//import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Cidade } from '../Interfaces/Cidade.interface';
import { Estado } from '../Interfaces/Estado.interface';
import { TipoDeCliente } from "../Interfaces/TipoDeCliente.interface";
import { TipoDePessoa } from "../Interfaces/TipoDePessoa.interface";


export class Dados
{
    //objs
    uri = 'http://localhost:56879/';
    clientApi: HttpClient ;

    estado: Estado;
    estados: Estado[];
    cidade: Cidade;
    cidades: Cidade[];
    tipoDeCliente: TipoDeCliente;
    tipoDePessoa: TipoDePessoa;

    constructor(client: HttpClient )
    {
        this.clientApi = client;
    }

    ObterCidades(uf: number)
        {
        this.clientApi.get<Cidade[]>(`${this.uri}Dados/Tipo/Cidade/${uf}`).subscribe(result =>
        {
          this.cidades = result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterCidade(id: number)
    {
        this.clientApi.get<Cidade>(`${this.uri}Dados/Tipo/Cidade/Obter/${id}`).subscribe(result =>
        {
          this.cidade = result;
        }, error =>
        {
            console.error(error)
        });
    }


    ObterTipoDeCliente(id: number)
    {
      this.clientApi.get<TipoDeCliente>(`${this.uri}Dados/Tipo/Cliente/${id}`).subscribe(result =>
        {
          this.tipoDeCliente = result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterTipoDePessoa(id: number)
    {
         this.clientApi.get<TipoDePessoa>(`${this.uri}Dados/Tipo/Pessoa/${id}`).subscribe(result =>
        {
          this.tipoDePessoa = result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterEstados()
    {
         this.clientApi.get<Estado[]>(`${this.uri}Dados/Tipo/Estado`).subscribe(result =>
        {
          this.estados =  result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterEstado(id: number)
    {
        this.clientApi.get<Estado>(`${this.uri}Dados/Tipo/Estado/${id}`).subscribe(result =>
        {
          this.estado = result;
        }, error =>
        {
            console.error(error)
        });
    }
  }
