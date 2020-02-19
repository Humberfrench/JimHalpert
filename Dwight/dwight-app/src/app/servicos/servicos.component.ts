import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


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
    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*',
      })
    };

    this.clientApi.get<Servicos[]>(this.uri + 'servicos',httpOptions).subscribe(result =>
    {
      this.servicos = result;
    }, error =>
    {
      console.error(error)
    });

  }
}

interface Servicos
{
  ServicoId: number;
  Descricao: string;
}