
using System;
using AARGOS.DATOS.Enums;

namespace AARGOS.DATOS.Entities
{
    /// <summary>
    /// Clase que representa una peticion HTTP
    /// </summary>
    public class HttpRequest<T>
    {
        /// <summary>
        /// Crea un nuevo objeto de peticion HTTP
        /// </summary>
        public HttpRequest() {
            Method = HttpMethod.GET;
            ContentType = ContentType.Text;
            Serialize = true;
        }

        /// <summary>
        /// Metodo Http
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// URL del recurso
        /// </summary>
        public Uri URL { get; set; }

        /// <summary>
        /// Datos de la peticion
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Contiene el tiempo de espera para la peticion
        /// </summary>
        public uint TimeOut { get; set; }

        /// <summary>
        /// Contiene el tipo de contenido para la peticion
        /// </summary>
        public ContentType ContentType { get; set; }

        /// <summary>
        /// Indica si se serializa la peticion
        /// </summary>
        public bool Serialize { get; set; }
    }
}
