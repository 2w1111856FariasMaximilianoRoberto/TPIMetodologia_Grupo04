using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Aplicacion.Dto
{
    public class UsuarioDto
    {
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
    }
}
