using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARGOS.DATOS;
using AARGOS.DATOS.Entities;
using AARGOS.DATOS.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace AARGOS.UNIT_TESTING.Datos
{
    /// <summary>
    /// Pruebas unitatias de la capa de datos
    /// </summary>
    [TestClass]
    public class DatosTest
    {

        [TestMethod]
        public void TestServicio()
        {
            WebServies servicio = new WebServies();
            const string url = "https://apitestcotizamatico.azurewebsites.net/api/catalogos";

            var wsResponse = servicio.CallService<object, string>(new HttpRequest<string>()
            {
                URL = new Uri(url),
                Method = HttpMethod.POST,
                ContentType = ContentType.Json,
                Data = "{\"Filtro\": \"1\",\"IdAplication\": 2,\"NombreCatalogo\": \"Marca\"}",
                Serialize= false
            });

            Assert.IsTrue(wsResponse.HttpCode == 200);

            var wsResponse2 = servicio.CallService<DummyResponse, object>(new HttpRequest<object>()
            {
                URL = new Uri(url),
                Method = HttpMethod.POST,
                ContentType = ContentType.Json,
                Data = new { Filtro = 1, IdAplicacion = 2, NombreCatalogo = "Marca" }
            });

            Assert.IsTrue(wsResponse2.HttpCode == 200);

        }

        [TestMethod]
        public void TestDatosCatalogo()
        {
            DatosCatalogo datosCatalogo = new DatosCatalogo();
            var marcas = datosCatalogo.ObtenerMarcas();
            Assert.IsTrue(marcas.Count() > 0);

            var subMarcas = datosCatalogo.ObtenerSubmarcas(marcas.FirstOrDefault().IdMarca);
            Assert.IsTrue(subMarcas.Count() > 0);
        }
    }

    

    public class DummyResponse
    {
        public string CatalogoJsonString { get; set; }

        public IEnumerable<CatalogElement> Catalogo 
        {
            get 
            {
                return JsonConvert.DeserializeObject<IEnumerable<CatalogElement>>(CatalogoJsonString ?? string.Empty);
            } 
        }
    }

    public class CatalogElement 
    {
        public int iIdMarca { get; set; }

        public string sMarca { get; set; }
    }
}
