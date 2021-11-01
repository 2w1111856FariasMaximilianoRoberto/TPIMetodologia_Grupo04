using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class Clientes
    {
        public Clientes()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoCliente { get; set; }
        public string Sexo { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdBarrio { get; set; }
        public int IdTipoRol { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
