using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            DetallePedidos = new HashSet<DetallePedidos>();
        }

        public int IdPedido { get; set; }
        public int IdFormaPago { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual FormasPago IdFormaPagoNavigation { get; set; }
        public virtual ICollection<DetallePedidos> DetallePedidos { get; set; }

        
    }
}
