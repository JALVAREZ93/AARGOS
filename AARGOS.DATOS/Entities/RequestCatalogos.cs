using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.DATOS.Entities
{
    /// <summary>
    /// Clase que contiene una peticion para los catalogos
    /// </summary>
    public class RequestCatalogos
    {
        /// <summary>
        /// Filtro de datos
        /// </summary>
        public string Filtro { get; set; }

        /// <summary>
        /// Ide de aplicacion
        /// </summary>
        const int ID_APP_SEGUROS = 2;
        
        /// <summary>
        /// Obtiene el id de aplicacion para los catalogos
        /// </summary>
        public int IdAplicacion 
        {
            get 
            {
                return ID_APP_SEGUROS; 
            }
        }

        /// <summary>
        /// Contiene el nombre del catalogo
        /// </summary>
        public string NombreCatalogo { get; set; }
    }
}
