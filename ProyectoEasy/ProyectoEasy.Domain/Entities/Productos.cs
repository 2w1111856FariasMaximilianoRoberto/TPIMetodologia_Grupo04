using System;
using System.Collections.Generic;



namespace ProyectoEasy.Domain.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            DetallePedidos = new HashSet<DetallePedidos>();
        }

        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public double Dimenciones { get; set; }
        public string Modelo { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int IdMarca { get; set; }
        public int IdRubro { get; set; }
        public int Stock { get; set; }

        public virtual Marcas IdMarcaNavigation { get; set; }
        public virtual Rubros IdRubroNavigation { get; set; }
        public virtual ICollection<DetallePedidos> DetallePedidos { get; set; }
    }
}
