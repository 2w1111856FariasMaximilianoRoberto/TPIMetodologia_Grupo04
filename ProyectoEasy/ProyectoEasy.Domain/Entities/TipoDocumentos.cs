using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class TipoDocumentos
    {
        public TipoDocumentos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
