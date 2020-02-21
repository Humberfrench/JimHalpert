import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { Servicos } from "../Interfaces/Servicos.Interfaces";
import { ToastService } from '../Util/toast-service';

@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html'
})


export class ServicosComponent
{
  uri = 'http://localhost:56879/';
  clientApi: HttpClient ;
  public servicos: Servicos[];
  public servico: Servicos;
  public nome: string;
  public id: number;
  editForm: FormGroup;

  constructor(private client: HttpClient,
              private modalService: NgbModal,
              private formBuilder: FormBuilder,
              public toastService: ToastService )
  {
    this.clientApi = client;
    this.ObterServicos();

    this.editForm = this.formBuilder.group({
      servicoId: ['',],
      nome: ['', Validators.compose([Validators.required])],
      descricao: ['', Validators.required]
    });

  }

  ObterServicos()
  {
    this.clientApi.get<Servicos[]>(this.uri + 'servicos').subscribe(result =>
    {
      this.servicos = result;
    }, error =>
    {
      console.error(error)
    });
  }

  ObterServico(id : number)
  {
    this.clientApi.get<Servicos>(this.uri + `servicos/${id}`).subscribe(result =>
    {
      this.servico = result;
      this.editForm.setValue(this.servico);
    }, error =>
    {
      console.error(error)
    });

  }

  Editar(modal: any, id: number)
  {
    this.ObterServico(id);
    this.modalService.open(modal, { size: 'lg',centered: true  });
  }

  Novo()
  {
    this.servico =
    {
      ServicoId: 0,
      Nome: '',
      Descricao: ''
    } as Servicos;
    this.editForm.setValue(this.servico);
  }

  Excluir(modal: any, id: number, descricao: string)
  {
    this.id = id;;
    this.nome = descricao;
    this.modalService.open(modal, { size: 'md',centered: true } ).result.then((result) =>
    {
      this.ExcluirRegistro(result, id)
    });
  }

  ExcluirRegistro(reason: string, id:number)
  {
      if(reason === 'N')
      {
        return;
      }
      this.EfetuaExclusao(id);

  }

  EfetuaExclusao(id: number)
  {
    this.clientApi.post(this.uri + `servicos\\Excluir\\${id}`, null).subscribe(result =>
      {
        this.ObterServicos();
      }, error =>
      {
        console.error(error)
      });
  }

}

