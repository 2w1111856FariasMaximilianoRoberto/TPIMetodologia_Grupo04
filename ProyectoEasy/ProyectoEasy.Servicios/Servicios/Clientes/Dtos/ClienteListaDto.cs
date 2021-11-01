using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEasy.Servicios.Dtos
{
    public class ClienteListaDto
    {
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
