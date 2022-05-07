using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARGOS.DATOS.Entities;
using AARGOS.DATOS.Enums;
using AARGOS.ENTITY;

namespace AARGOS.DATOS
{
    /// <summary>
    /// Contiene los metodos de acceso a los datos de los catalogos
    /// </summary>
    public class DatosCatalogo
    {
        /// <summary>
        /// URL del servicio de catalogos
        /// </summary>
        const string URL = "https://apitestcotizamatico.azurewebsites.net/api/catalogos";

        /// <summary>
        /// Obtiene las marcas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        public IEnumerable<CatMarca> ObtenerMarcas()
        {
            return ObtenerCatalogo<CatMarca>(1, "Marca");
        }

        /// <summary>
        /// Obtiene la lista de submarcas dada un id de marca
        /// </summary>
        /// <param name="idMarca">Id de Marca</param>
        /// <returns>Lista de submarcas</returns>
        public IEnumerable<CatSubMarca> ObtenerSubmarcas(int idMarca)
        {
            return ObtenerCatalogo<CatSubMarca>(idMarca, "Submarca");
        }

        /// <summary>
        /// Obtiene la lista de modelos dado un id de submarca 
        /// </summary>
        /// <param name="idSubmarca">Id de la submarca</param>
        /// <returns>Lista de modelos</returns>
        public IEnumerable<CatModelo> ObtenerModelos(int idSubmarca)
        {
            return ObtenerCatalogo<CatModelo>(idSubmarca, "Modelo");
        }

        /// <summary>
        /// Obtiene la lista de descripciones para los modelos dado un id de modelo
        /// </summary>
        /// <param name="idModelo">Id de modelo</param>
        /// <returns>Lista de descripciones de modelos</returns>
        public IEnumerable<CatModeloDescripcion> ObtenerDescripcionModelos(int idModelo)
        {
            return ObtenerCatalogo<CatModeloDescripcion>(idModelo, "DescripcionModelo");
        }

        /// <summary>
        /// Obtiene la direccion a partir del codigo postal
        /// </summary>
        /// <param name="codigoPostal">Codigo postal</param>
        /// <returns>Lista de direcciones asociadas al codigo postal</returns>
        public IEnumerable<CatSepomex> ObtenerDireccion(int codigoPostal)
        {
            return ObtenerCatalogo<CatSepomex>(codigoPostal, "Sepomex");
        }


        /// <summary>
        /// Metodo de consuta generico para los catalogos
        /// </summary>
        /// <typeparam name="CATALOGO">Tipo de catalogo</typeparam>
        /// <param name="filtro">Filtro</param>
        /// <param name="catalogo">Catalogo</param>
        /// <returns>Lista de elementos del catalogo</returns>
        private IEnumerable<CATALOGO> ObtenerCatalogo<CATALOGO>(int filtro, string catalogo)
        {
            WebServies ws = new WebServies();
            var wsResponse = ws.CallService<ResponseCatalogos<CATALOGO>, RequestCatalogos>(new HttpRequest<RequestCatalogos>()
            {
                URL = new Uri(URL),
                ContentType = ContentType.Json,
                Method = HttpMethod.POST,
                Data = new RequestCatalogos() { Filtro = filtro.ToString(), NombreCatalogo = catalogo }
            });
            return wsResponse.Data.Catalogo;
        }

    }
}
