using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Dtos
{
    public class UsuarioListadoDto
    {
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
    }
}
