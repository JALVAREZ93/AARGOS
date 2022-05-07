using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARGOS.DATOS.Enums;

namespace AARGOS.DATOS.Entities
{
    /// <summary>
    /// Clase que contiene la respuesta de un servicio
    /// </summary>
    /// <typeparam name="T">Tipo de la respuesta</typeparam>
    public class HttpResponse<T>
    {
        /// <summary>
        /// Crea un nuevo objeto de respuesta
        /// </summary>
        /// <param name="contentType">ContentType</param>
        public HttpResponse(ContentType contentType,string content, T data) { 
            ContentType = contentType;
            RawContent = content;
            Data = data;
        }

        /// <summary>
        /// Contenido en texto de la respuesta
        /// </summary>
        public string RawContent { get; private set; }

        /// <summary>
        /// Datos de la respuesta
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Tipo de contenido para la respuesta
        /// </summary>
        public ContentType ContentType { get; private set; }

        /// <summary>
        /// Contiene el codigo HTTP
        /// </summary>
        public int HttpCode { get; set; }

    }
}
