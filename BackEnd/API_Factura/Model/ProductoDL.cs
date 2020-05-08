using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Model
{
    public class ProductoDL
    {
        //Arma el encabezado del sqlCommand
        private SqlCommand armarComando(string procedimientoAlmacenado) {
            SqlCommand  common = new SqlCommand();
            common.Connection = Conexion.Conexion.obtenerConexion();
            common.CommandType = System.Data.CommandType.StoredProcedure;
            common.CommandText = procedimientoAlmacenado;
            return common;
        }
        //CRUD
        //Realiza el insertar del producto
        public void insertarProducto(Producto producto)
        {
            try
            {
               
                    using (SqlCommand sentencia = armarComando("[sp_Productos_Insertar]"))
                    {
                        sentencia.Parameters.Add(new SqlParameter("@pValor", SqlDbType.Float)).Value = producto.valor;
                        sentencia.Parameters.Add(new SqlParameter("@pNombre", SqlDbType.NVarChar)).Value = producto.nombre;
                        sentencia.ExecuteNonQuery();
                    }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Realiza el modificar del producto
        public void modificarProducto(Producto producto)
        {
            try
            {

                using (SqlCommand sentencia = armarComando("[sp_Productos_Actualizar]"))
                {
                    sentencia.Parameters.Add(new SqlParameter("@pCodigo", SqlDbType.Int)).Value = producto.codigo;
                    sentencia.Parameters.Add(new SqlParameter("@pValor", SqlDbType.Float)).Value = producto.valor;
                    sentencia.Parameters.Add(new SqlParameter("@pNombre", SqlDbType.NVarChar)).Value = producto.nombre;
                    sentencia.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Realiza el eliminar del producto
        public void eliminarProducto(string codigo)
        {
            try
            {
                using (SqlCommand sentencia = armarComando("[sp_Productos_Eliminar]"))
                {
                    sentencia.Parameters.Add(new SqlParameter("@pCodigo", SqlDbType.Int)).Value = codigo;
                    sentencia.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Realiza la consulta de los productos
        public List<Producto> obtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            Producto producto = null;
            try
            {
                using (SqlCommand sentencia = armarComando("[dbo].[sp_Productos_Obtener]"))
                {
                    using (SqlDataReader lector = sentencia.ExecuteReader())
                    {
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                producto = new Producto();
                                producto.codigo = lector.GetInt32(0);
                                producto.valor = (double)lector.GetDecimal(1);
                                producto.nombre = lector.GetString(2);
                                productos.Add(producto);
                            }
                        }
                   
                    }

                }
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Realiza la consulta de algun producto en especifico
        public Producto obtenerProducto(string id)
        {
            Producto productos = new Producto();
            Producto producto = null;
            try
            {
                using ( SqlCommand sentencia = armarComando("[dbo].[sp_Productos_Obtener]"))
                {
                    sentencia.Parameters.Add(new SqlParameter("@pCodigo", SqlDbType.Int)).Value = int.Parse(id);
                    using (SqlDataReader lector = sentencia.ExecuteReader())
                    {
                       
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {   
                                producto = new Producto();
                                producto.codigo = lector.GetInt32(0);
                                producto.valor = (double)lector.GetDecimal(1);
                                producto.nombre = lector.GetString(2);
                                return producto;
                            }
                        }

                    }

                }
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
