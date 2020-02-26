import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { Cliente } from '../Interfaces/Cliente.interface';
import { TipoDePessoa } from '../Interfaces/TipoDePessoa.interface';
import { TipoDeCliente } from '../Interfaces/TipoDeCliente.interface';
import { Cidade } from '../Interfaces/Cidade.interface';
import { Estado } from '../Interfaces/Estado.interface';

@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html'
  })

  export class ClientesComponent
  {
    uri = 'http://localhost:56879/';
    clientApi: HttpClient ;

    public nome: string;
    public id: number;
    editForm: FormGroup;
    clientes: Cliente[];
    cliente: Cliente;
    tipoDePessoa: TipoDePessoa;
    tipoDePessoas: TipoDePessoa[];
    tipoDeCliente: TipoDeCliente;
    tipoDeClientes: TipoDeCliente[];
    cidade: Cidade;
    cidades: Cidade[];
    estado: Estado;
    estados: Estado[];

    constructor(clientApi: HttpClient,
                private modalService: NgbModal,
                private formBuilder: FormBuilder)
    {
      this.clientApi = clientApi;
      this.ObterClientes();
      this.ObterTipoDeClientes();
      this.ObterTipoDePessoas();
      this.ObterEstados();

      this.editForm = this.formBuilder.group({
        clienteId: [{value: '0', disabled: true}, Validators.required],
        nome: ['', Validators.required],
        razaoSocial: ['', Validators.required],
        documento: ['', Validators.required],
        tipoDeClienteId: ['', Validators.required],
        tipoDePessoaId: ['', Validators.required],
        telefone: ['', ],
        contato: ['', ],
        email: ['', ],
        inscricaoEstadual: ['', ],
        cadastroMunicipal: ['', ],
        endereco: ['', ],
        numero: ['', ],
        complemento: ['', ],
        bairro: ['', ],
        cep: ['', ],
        cidadeId: ['', ],
        dataCriacao: ['', ],
        dataAlteracao: ['', ]
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
      this.modalService.open(modal, { size: 'lg',centered: true  });
    }

    ObterTipoDePessoas()
    {
        this.clientApi.get<TipoDePessoa[]>(`${this.uri}Dados/Tipo/Pessoa`).subscribe(result =>
        {
          this.tipoDePessoas = result;
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

    ObterTipoDeClientes()
    {
        this.clientApi.get<TipoDeCliente[]>(`${this.uri}Dados/Tipo/Cliente`).subscribe(result =>
        {
          this.tipoDeClientes = result;
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

    onChangeEstado($event) {
      const uf: number = $event.currentTarget.value;
      if (uf === 0) {
        return;
      }

      this.ObterCidades(uf);;
    }

    ObterCidades(uf: number)
    {
      this.clientApi.get<Cidade[]>(`${this.uri}Dados/Tipo/Cidade/${uf}`).subscribe(result => {
        this.cidades = result;
      }, error => {
        console.error(error)
      });
    }

    ObterCidade(id: number) {
      this.clientApi.get<Cidade>(`${this.uri}Dados/Tipo/Cidade/Obter/${id}`).subscribe(result => {
        this.cidade = result;
      }, error => {
        console.error(error)
      });
    }
    ObterEstados() {
      this.clientApi.get<Estado[]>(`${this.uri}Dados/Tipo/Estado`).subscribe(result => {
        this.estados = result;
      }, error => {
        console.error(error)
      });
    }

    ObterEstado(id: number) {
      this.clientApi.get<Estado>(`${this.uri}Dados/Tipo/Estado/${id}`).subscribe(result => {
        this.estado = result;
      }, error => {
        console.error(error)
      });
    }
  }
