
//import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Cidade } from '../Interfaces/Cidade.interface';
import { Estado } from '../Interfaces/Estado.interface';
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
        let cidades : Cidade[];  
        this.clientApi.get<Cidade[]>(`${this.uri}Dados/Tipo/Cidade/${uf}`).subscribe(result =>
        {
            cidades = result;
        }, error =>
        {
            console.error(error)
        });
        return cidades;        
    }

    ObterCidade(id: number)
    {
        let cidade : Cidade;  
        this.clientApi.get<Cidade>(`${this.uri}Dados/Tipo/Cidade/Obter/${id}`).subscribe(result =>
        {
            cidade = result;
        }, error =>
        {
            console.error(error)
        });
        return cidade;        
    }

    ObterTipoDeClientes(): TipoDeCliente[]
    {
        let tipoDeClientes : TipoDeCliente[];  
        this.clientApi.get<TipoDeCliente[]>(`${this.uri}Dados/Tipo/Pessoa`).subscribe(result =>
        {
            tipoDeClientes = result;
        }, error =>
        {
            console.error(error)
        });
        return tipoDeClientes;        
    }

    ObterTipoDeCliente(id: number): TipoDeCliente
    {
        let tipoDeCliente : TipoDeCliente;  
        this.clientApi.get<TipoDeCliente>(`${this.uri}Dados/Tipo/Cliente/${id}`).subscribe(result =>
        {
            tipoDeCliente = result;
        }, error =>
        {
            console.error(error)
        });
        return tipoDeCliente;        
    }
    
    ObterTipoDePessoas()
    {
        let tipoDePessoas : TipoDePessoa[];      
        this.clientApi.get<TipoDePessoa[]>(`${this.uri}Dados/Tipo/Pessoa`).subscribe(result =>
        {
            tipoDePessoas = result;
        }, error =>
        {
            console.error(error)
        });
        return tipoDePessoas;        
    }

    ObterTipoDePessoa(id: number) : TipoDePessoa
    {
        let tipoDePessoa : TipoDePessoa;
        this.clientApi.get<TipoDePessoa>(`${this.uri}Dados/Tipo/Pessoa/${id}`).subscribe(result =>
        {
            tipoDePessoa = result;
        }, error =>
        {
            console.error(error)
        });
        return tipoDePessoa;        
    }
    
    ObterEstados() : Estado[]
    {
        let estados : Estado[];
        this.clientApi.get<Estado[]>(`${this.uri}Dados/Tipo/Estado`).subscribe(result =>
        {
            estados =  result;
        }, error =>
        {
            console.error(error)
        });
        return estados;        
    }

    ObterEstado(id: number) : Estado
    {
        let estado : Estado;
        this.clientApi.get<Estado>(`${this.uri}Dados/Tipo/Estado/${id}`).subscribe(result =>
        {
            estado = result;
        }, error =>
        {
            console.error(error)
        });
        return estado;        
    }}