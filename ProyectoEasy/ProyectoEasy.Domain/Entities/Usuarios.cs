using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public int IdRol { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdBarrio { get; set; }

        public virtual Barrios IdBarrioNavigation { get; set; }
        public virtual TipoRoles IdRolNavigation { get; set; }
        public virtual TipoDocumentos IdTipoDocumentoNavigation { get; set; }
    }
}
