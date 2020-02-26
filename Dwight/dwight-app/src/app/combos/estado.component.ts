import { Estado } from '../Interfaces/Estado.interface';
import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-estado',
  template: `
  <select id="estadoId" name="estadoId" formControlName="estadoId" class="form-control">
  <option value="0" ng-selected="myvalue == 0">Selecione Tipo</option>
  <option ng-selected="myvalue == estado.estadoId" *ngFor="let estado as Estado of estados" value={{estado.EstadoId}}>{{Estado.siglaUf}} - {{Estado.nomeUf}}</option>
  </select>
`
})

export class EstadoComponent
{


    //objs
    uri  = 'http://localhost:56879/';
    clientApi: HttpClient ;
    estado: Estado;
    estados: Estado[];
    @Input()
    myvalue: number;

  constructor(client: HttpClient )
  {
      this.clientApi = client;
      this.myvalue = 0;
      this. ObterEstados();
  }

  ObterEstados()
  {
       this.clientApi.get<Estado[]>(`${this.uri}Dados/Tipo/Estado`).subscribe(result =>
      {
        this.estados =  result;
      }, error =>
      {
          console.error(error)
      });
  }

  ObterEstado(id: number)
  {
      this.clientApi.get<Estado>(`${this.uri}Dados/Tipo/Estado/${id}`).subscribe(result =>
      {
        this.estado = result;
      }, error =>
      {
          console.error(error)
      });
  }
}
