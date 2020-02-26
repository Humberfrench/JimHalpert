import { TipoDePessoa } from '../Interfaces/TipoDePessoa.interface';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


@Component({
  selector: 'app-tipo-pessoa',
  template: `
  <select id="tipoDePessoaId" name="tipoDePessoaId" formControlName="tipoDePessoaId" class="form-control">
    <option *ngFor="let tipoDePessoa as TipoDePessoa of tipoDePessoas" value={{tipoDePessoa.tipoDePessoaId}}>{{tipoDePessoa.descricao}}</option>
  </select>
`
})



export class TipoDePessoaComponent
{
     //objs
     uri  = 'http://localhost:56879/';
     clientApi: HttpClient ;
     tipoDePessoa: TipoDePessoa;
     tipoDePessoas: TipoDePessoa[];

  constructor(client: HttpClient )
  {
      this.clientApi = client;
      this. ObterTipoDePessoas();
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
}
