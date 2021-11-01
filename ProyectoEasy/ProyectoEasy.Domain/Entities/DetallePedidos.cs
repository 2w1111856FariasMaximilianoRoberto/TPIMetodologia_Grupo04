// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class DetallePedidos
    {
        public int IdDetallePedido { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }

        public virtual Pedidos IdPedidoNavigation { get; set; }
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
