import { Cidade } from '../Interfaces/Cidade.interface';
import { Estado } from '../Interfaces/Estado.interface';
import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-cidade',
  styles: ['.rowapp {  margin: 10px; padding:  10px; }',],
  template: `
  <div class="row rowapp">
  <div class="col-3 sol-sm-3 col-md-3 col-lg-3 col-xl-3">
    <div class="form-group">
      <label for="estadoId">Estado</label>
      <select id="estadoId" name="estadoId" formControlName="estadoId" class="form-control" (change)="onChange($event)">
        <option value="0" ng-selected="myvalue == 0">Selecione Uf</option>
        <option ng-selected="myvalue == estado.estadoId" *ngFor="let estado as Estado of estados" value={{estado.estadoId}}>{{estado.siglaUf}} - {{estado.nomeUf}}</option>
      </select>
    </div>
  </div>
  <div class="col-8 sol-sm-8 col-md-8 col-lg-8 col-xl-8">
    <div class="form-group">
      <label for="cidadeId">Cidade</label>
      <select id="cidadeId" name="cidadeId" formControlName="cidadeId" class="form-control" (change)="cidadeChange($event)">
        <option value="0" ng-selected="myvalue == 0">Selecione Cidade</option>
        <option ng-selected="myvalue == cidade.cidadeId" *ngFor="let cidade as cidade of cidades" value={{cidade.cidadeId}}>{{cidade.nome}}</option>
      </select>
    </div>
  </div>
  </div>
`
})

export class CidadeComponent {
  //objs
  uri = 'http://localhost:56879/';
  clientApi: HttpClient;
  cidade: Cidade;
  cidades: Cidade[];
  estado: Estado;
  estados: Estado[];

  @Input()
  myvalue: number;

  constructor(client: HttpClient) {
    this.clientApi = client;
    this.myvalue = 0;
    // this.uf = 0;
    this.ObterEstados();

  }

  onChange($event) {
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
