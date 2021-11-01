using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class Barrios
    {
        public Barrios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdBarrio { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
