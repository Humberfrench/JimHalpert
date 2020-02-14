import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Servico } from "../interfaces/servico.interface"

@Component({
  selector: 'app-servico',
  templateUrl: './servico.component.html'
})

export class ServicoComponent
{
  public Servicos: Servico[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<Servico[]>(baseUrl + 'Servico/ObterTodos').subscribe(result =>
    {
      this.Servicos = result;
    }, error => console.error(error));
  }
}

