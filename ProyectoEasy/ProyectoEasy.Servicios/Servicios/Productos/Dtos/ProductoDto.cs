using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Dtos
{
  public class ProductoDto
    {
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public double Dimenciones { get; set; }
        public string Modelo { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int IdMarca { get; set; }
        public int IdRubro { get; set; }
        public int Stock { get; set; }
    }
}
