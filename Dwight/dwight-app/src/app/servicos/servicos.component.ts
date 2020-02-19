import { Component, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html'
})


export class ServicosComponent
{
  uri: string  = 'http://localhost:56879/';
  clientApi: HttpClient ;
  public servicos: Servicos[];
  public servico: Servicos;
  public showModal: boolean;

  @ViewChild('modalEditar') modalEditar: any;

  constructor(client: HttpClient)
  {
    this.clientApi = client;
    this.ObterServicos();
    this.showModal = false;
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

  Editar(id: number)
  {
    this.showModal = true;
  }

  Novo()
  {

  }

   Excluir(id: number)
  {
    alert(id);
    //this.clientApi.get<Servicos[]>(this.uri + `servicos/excluir/${id}`).subscribe(result =>
     // {
      //  this.servicos = result;
      //}, error =>
     // {
     //   console.error(error)
     // });
  }
}

interface Servicos
{
  ServicoId: number;
  Descricao: string;
}
