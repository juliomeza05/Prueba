import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Producto } from '../Interfaces/Producto';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {
  API_ENDPOINT ='https://localhost:44366/api/Factura';
  productos: Producto[];
  constructor(private httpclient: HttpClient ) { }
  guardar(producto: Producto)
  {
   const  cabecera = new HttpHeaders({ 'Content-Type':'application/json'});
   return this.httpclient.post(this.API_ENDPOINT + '/Insertar',producto,{ headers: cabecera});
  }
  actualizar(producto: Producto)
  {
   const  cabecera = new HttpHeaders({ 'Content-Type':'application/json'});
   return this.httpclient.put(this.API_ENDPOINT + '/Actualizar',producto,{ headers: cabecera});
  }
  obtenerRegistro()
  {
    return   this.httpclient.get(this.API_ENDPOINT + '/ObtenerProductos');
  }
  obtenerProducto(id:string )
  {
    return   this.httpclient.get(this.API_ENDPOINT + '/ObtenerProducto?id=' + id);
  }
  eliminarProducto(id:string )
  {
    return   this.httpclient.delete(this.API_ENDPOINT + '/Eliminar?id=' + id);
  }
}
