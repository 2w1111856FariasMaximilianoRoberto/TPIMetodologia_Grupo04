using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEasy.Servicios.Dtos
{
    public class ClienteDto
    {
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

        //public int IdTipoRol { get; set; }
    }
}
