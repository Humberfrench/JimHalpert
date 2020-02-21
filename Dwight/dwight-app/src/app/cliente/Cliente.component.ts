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
    uri = 'http://localhost:56879/';
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

    constructor(clientApi: HttpClient,
                private modalService: NgbModal,
                private formBuilder: FormBuilder,)
    {
      this.clientApi = clientApi;
      this.dados = new Dados(clientApi);
      this.dados.ObterEstados();
      this.dados.ObterTipoDeClientes();
      this.dados.ObterTipoDePessoas();

      this.estados = this.dados.estados;
      this.tipoDeClientes = this.dados.tipoDeClientes;
      this.tipoDePessoas = this.dados.tipoDePessoas;

      this.ObterClientes();

      this.editForm = this.formBuilder.group({
        clienteId: ['',],
        nome: ['',Validators.required],
        razaoSocial: ['',Validators.required],
        documento: ['',Validators.required],
        tipoDeClienteId: ['',Validators.required],
        tipoDePessoaId: ['',Validators.required],
        telefone: ['',],
        contato: ['',],
        email: ['',],
        inscricaoEstadual: ['',],
        cadastroMunicipal: ['',],
        endereco: ['',],
        numero: ['',],
        complemento: ['',],
        bairro: ['',],
        cep: ['',],
        cidadeId: ['',]
      });
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
        this.editForm.setValue(this.cliente);
      }, error =>
      {
        console.error(error)
      });

    }

    Editar(modal: any, id: number)
    {
      this.ObterCliente(id);
      this.modalService.open(modal, { size: 'xl',centered: true  });
    }
  }
