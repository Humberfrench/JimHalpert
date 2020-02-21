
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Cidade } from '../Interfaces/Cidade.interface';
import { TipoDeCliente } from "../Interfaces/TipoDeCliente.interface";
import { TipoDePessoa } from "../Interfaces/TipoDePessoa.interface";


export class Dados
{
    //objs
    uri: string  = 'http://localhost:56879/';
    clientApi: HttpClient ;

    constructor(client: HttpClient ) 
    {
        this.clientApi = client;
    }

    ObterCidades(uf: number)
    {
        this.clientApi.get<Cidade[]>(`${this.uri}Dados/Tipo/Cliente/${id}`).subscribe(result =>
        {
            return result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterCidade(id: number)
    {
        this.clientApi.get<Cidade>(`${this.uri}Dados/Tipo/Cliente/${id}`).subscribe(result =>
        {
            return result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterTipoDeClientes()
    {
        this.clientApi.get<TipoDeCliente[]>(`${this.uri}Dados/Tipo/Pessoa`).subscribe(result =>
        {
            return result;
        }, error =>
        {
            console.error(error)
        });

    }

    ObterTipoDeCliente(id: number)
    {
        this.clientApi.get<TipoDeCliente>(`${this.uri}Dados/Tipo/Cliente/${id}`).subscribe(result =>
        {
            return result;
        }, error =>
        {
            console.error(error)
        });
    }
    
    ObterTipoDePessoas()
    {
        this.clientApi.get<TipoDePessoa[]>(`${this.uri}Dados/Tipo/Pessoa`).subscribe(result =>
        {
            return result;
        }, error =>
        {
            console.error(error)
        });
    }

    ObterTipoDePessoa(id: number)
    {
        this.clientApi.get<TipoDePessoa>(`${this.uri}Dados/Tipo/Pessoa/${id}`).subscribe(result =>
        {
            return result;
        }, error =>
        {
            console.error(error)
        });
    }
}