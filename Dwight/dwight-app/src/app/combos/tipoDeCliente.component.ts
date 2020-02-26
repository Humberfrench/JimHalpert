import { TipoDeCliente } from '../Interfaces/TipoDeCliente.interface';
import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-tipo-cliente',
  template: `
  <select id="tipoDeClienteId" name="tipoDeClienteId" formControlName="tipoDeClienteId" class="form-control">
  <option value="0" ng-selected="myvalue == 0">Selecione Tipo</option>
  <option ng-selected="myvalue == tipoDeCliente.tipoDeClienteId" *ngFor="let tipoDeCliente as TipoDeCliente of tipoDeClientes" value={{tipoDeCliente.tipoDeClienteId}}>{{tipoDeCliente.descricao}}</option>
  </select>
`
})

export class TipoDeClienteComponent
{


    //objs
    uri  = 'http://localhost:56879/';
    clientApi: HttpClient ;
    tipoDeCliente: TipoDeCliente;
    tipoDeClientes: TipoDeCliente[];
    @Input()
    myvalue: number;

  constructor(client: HttpClient )
  {
      this.clientApi = client;
      this.myvalue = 0;
      this. ObterTipoDeClientes();
  }

  ObterTipoDeClientes()
  {
      this.clientApi.get<TipoDeCliente[]>(`${this.uri}Dados/Tipo/Cliente`).subscribe(result =>
      {
        this.tipoDeClientes = result;
       }, error =>
      {
          console.error(error)
      });
  }

  ObterTipoDeCliente(id: number)
  {
       this.clientApi.get<TipoDeCliente>(`${this.uri}Dados/Tipo/Cliente/${id}`).subscribe(result =>
      {
        this.tipoDeCliente = result;
      }, error =>
      {
          console.error(error)
      });
  }
}
