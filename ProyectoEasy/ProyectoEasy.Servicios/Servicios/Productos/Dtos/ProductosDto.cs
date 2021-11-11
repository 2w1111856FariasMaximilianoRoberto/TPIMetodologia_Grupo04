using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Dtos
{
    public class ProductosDto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public double Dimenciones { get; set; }
        public string Modelo { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public string Marca { get; set; }
        public string Rubro { get; set; }
        public int Stock { get; set; }
    }
}
