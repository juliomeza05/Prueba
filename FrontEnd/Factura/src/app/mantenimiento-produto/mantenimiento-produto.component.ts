import { Component, OnInit } from '@angular/core';
import { Producto } from '../Interfaces/Producto';
import { ProductosService } from '../Servicios/productos.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-mantenimiento-produto',
  templateUrl: './mantenimiento-produto.component.html',
  styleUrls: ['./mantenimiento-produto.component.css']
})
export class MantenimientoProdutoComponent implements OnInit {
  producto: Producto =
  {
    codigo : null,
    valor : null,
    nombre:null
  };

  id: any;
  editar: boolean;
  constructor(private servicioProdcutos: ProductosService,private activate: ActivatedRoute) { 
    this.id = this.activate.snapshot.params['id'];
    console.log(this.id);
    servicioProdcutos.obtenerProducto(this.id).subscribe((data:Producto)=>{
      this.producto = data;
    },(error)=>{
      console.log('Ocurrio un error');
    })

    this.editar=false;
    if(this.id){
      this.editar=true;
    }
  }

  ngOnInit(): void {
  }
  
  AccionProducto(){
    if(this.editar)
    {
     this. actualizar();
    }else{
      this.guardarProducto();
    }
  }
  guardarProducto(){
    this.servicioProdcutos.guardar(this.producto).subscribe((data)=>
    {
      alert('Registro guardado');
      console.log(data);
    },
    (error)=>{
        console.log(error);
        alert('Ocurrio un error');
    });
  }
  actualizar(){
    this.servicioProdcutos.actualizar(this.producto).subscribe((data)=>
    {
      alert('Registro Actualizado');
      console.log(data);
    },
    (error)=>{
        console.log(error);
        alert('Ocurrio un error');
    });
  }
}
