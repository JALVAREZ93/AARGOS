using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AARGOS.DATOS.Entities
{
    /// <summary>
    /// Contieneña respuesta generica des servicio de catalogos
    /// </summary>
    /// <typeparam name="CATALOGO">Tipo catalogo</typeparam>
    public class ResponseCatalogos<CATALOGO>
    {
        /// <summary>
        /// Contiene los elementos catalogo en JsonString
        /// </summary>
        public string CatalogoJsonString { get; set; }

        /// <summary>
        /// Lista de catalogos
        /// </summary>
        public IEnumerable<CATALOGO> Catalogo 
        { 
            get 
            { 
                return JsonConvert.DeserializeObject<IEnumerable<CATALOGO>>(CatalogoJsonString ?? string.Empty); 
            }
        }
    }
}
