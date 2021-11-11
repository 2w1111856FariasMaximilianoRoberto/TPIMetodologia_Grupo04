using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoEasy.Aplicacion.Servicios;
using ProyectoEasy.Domain.Entities;

namespace AuthTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public  void ValidarSiCreaTipoDoc()
        {
            TipoDocumentoServicio servicio = new TipoDocumentoServicio();

            TipoDocumentos tipo = new TipoDocumentos();
            tipo.Descripcion = "lalla2";

            var resultado = servicio.Crear(tipo);


            Assert.IsFalse(resultado.IsCompletedSuccessfully);

        }
    }
}
