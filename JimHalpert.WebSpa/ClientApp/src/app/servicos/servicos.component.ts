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

  constructor(client: HttpClient)
  {
    this.clientApi = client;
  }

}
