import { Component, OnInit } from '@angular/core';
import { ProductosService } from '../Servicios/productos.service';
import { Producto } from "../Interfaces/Producto";
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  API_ENDPOINT ='https://localhost:44366/api/Factura';
  productos: Producto[];
  constructor(private servicioProducto: ProductosService) 
  {
    this.cargarProductos();
  }
  ngOnInit(): void { 

  }
  
  cargarProductos(){
    this.servicioProducto.obtenerRegistro().subscribe((data :Producto[])=>{
      this.productos = data;
      console.log(  this.productos) });
  }
  eliminarProducto(id){
    if(confirm('¿Desea eliminar el producto?'))
    {
      console.log(id);
      this.servicioProducto.eliminarProducto(id).subscribe((data)=>{
        alert('Registro Eliminado');
        this.cargarProductos();
      });

    }
  }
}
