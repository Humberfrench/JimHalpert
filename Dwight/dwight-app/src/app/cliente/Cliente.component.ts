import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { Cliente } from '../Interfaces/Cliente.interface';

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

    constructor(clientApi: HttpClient,
                private modalService: NgbModal,
                private formBuilder: FormBuilder)
    {
      this.clientApi = clientApi;
      this.ObterClientes();

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
  }
