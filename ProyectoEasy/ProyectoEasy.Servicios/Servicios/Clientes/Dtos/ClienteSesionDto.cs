using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Dtos
{
    public class ClienteSesionDto
    {
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
