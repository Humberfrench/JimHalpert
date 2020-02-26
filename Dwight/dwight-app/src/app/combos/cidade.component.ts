import { Cidade } from '../Interfaces/Cidade.interface';
import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-tipo-cliente',
  template: `
  <select id="CidadeId" name="CidadeId" formControlName="CidadeId" class="form-control">
  <option value="0" ng-selected="myvalue == 0">Selecione Tipo</option>
  <option ng-selected="myvalue == Cidade.CidadeId" *ngFor="let Cidade as Cidade of Cidades" value={{Cidade.CidadeId}}>{{Cidade.descricao}}</option>
  </select>
`
})

export class CidadeCompomnent
{


    //objs
    uri  = 'http://localhost:56879/';
    clientApi: HttpClient ; Cidade: Cidade;
    Cidades: Cidade[];
    @Input()
    myvalue: number;

  constructor(client: HttpClient )
  {
      this.clientApi = client;
      this.myvalue = 0;
      this. ObterCidades();
  }

  ObterCidades(uf: number)
  {
  this.clientApi.get<Cidade[]>(`${this.uri}Dados/Tipo/Cidade/${uf}`).subscribe(result =>
  {
    this.cidades = result;
  }, error =>
  {
      console.error(error)
  });
}

ObterCidade(id: number)
{
  this.clientApi.get<Cidade>(`${this.uri}Dados/Tipo/Cidade/Obter/${id}`).subscribe(result =>
  {
    this.cidade = result;
  }, error =>
  {
      console.error(error)
  });
}
}
