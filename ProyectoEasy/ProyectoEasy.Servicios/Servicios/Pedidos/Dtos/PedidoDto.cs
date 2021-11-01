using System;
using System.Collections.Generic;

namespace ProyectoEasy.Aplicacion.Dtos
{
    public class PedidoDto
    {
        public int IdFormaPago { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleDto> DetallePedidos { get; set; }  //Agrego una lista de detalles para despues poderla recorrer con un foreach y asi insertar los Detalles al momento de crear el pedido.
    }
}
