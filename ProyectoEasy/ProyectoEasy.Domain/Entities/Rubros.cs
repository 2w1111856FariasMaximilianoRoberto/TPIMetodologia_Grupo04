using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoEasy.Domain.Entities
{
    public partial class Rubros
    {
        public Rubros()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdRubro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
