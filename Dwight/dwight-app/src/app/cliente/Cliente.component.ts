import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { Cliente } from "../Interfaces/Cliente.interface";
import { Cidade } from '../Interfaces/Cidade.interface';
import { Estado } from '../Interfaces/Estado.interface';
import { TipoDeCliente } from '../Interfaces/TipoDeCliente.interface';
import { TipoDePessoa } from '../Interfaces/TipoDePessoa.interface';
import { Dados } from '../Util/Dados.component';

@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html'
  })

  export class ClientesComponent
  {
    uri: string  = 'http://localhost:56879/';
    clientApi: HttpClient ;
    cidades: Cidade[];
    tipoDeClientes: TipoDeCliente[]
    tipoDePessoas: TipoDePessoa[]
    cliente: Cliente;
    clientes: Cliente[];
    estados: Estado[];
    dados: Dados;
    public nome: string;
    public id: number;
    editForm: FormGroup;


    constructor (clientApi: HttpClient)
    {
      this.clientApi = clientApi;
      this.estados = this.dados.ObterEstados()      
      this.tipoDeClientes = this.dados.ObterTipoDeClientes()      
      this.tipoDePessoas = this.dados.ObterTipoDePessoas()
      this.ObterClientes();
    }

    ObterClientes(): void
    {
      this.clientApi.get<Cliente[]>(this.uri + 'Clientes').subscribe(result =>
      {
        this.clientes = result;
      }, error =>
      {
        console.error(error)
      });
    }
  
    ObterCliente(id : number): void
    {
      this.clientApi.get<Cliente>(this.uri + `Clientes\\${id}`).subscribe(result =>
      {
        this.cliente = result;
        //this.editForm.setValue(this.Cliente);    
      }, error =>
      {
        console.error(error)
      });
  
    }
  
  }