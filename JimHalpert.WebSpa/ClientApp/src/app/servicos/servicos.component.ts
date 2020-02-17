import { Component } from '@angular/core';
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

  constructor(client: HttpClient)
  {
    this.clientApi = client;
    this.ObterServicos();

  }
  ObterServicos()
  {
    this.clientApi.get<Servicos[]>(this.uri + 'servicos').subscribe(result =>
    {
      this.servicos = result;
    }, error => console.error(error));

  }
}

interface Servicos
{
  ServicoId: number;
  Descricao: string;
}
