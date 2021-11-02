using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Aplicacion.Servicios.Dtos
{
    public class UsuarioSesionDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
