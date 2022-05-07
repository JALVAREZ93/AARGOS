using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.DATOS.Enums
{
    /// <summary>
    /// Enumera los tipos de contenido para las respuestas y peticiones HTTP
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// Tipo de contenido HTML
        /// </summary>
        Html,

        /// <summary>
        /// Tipo de contenido formulario
        /// </summary>
        Form,

        /// <summary>
        /// Tipo de contenido XML
        /// </summary>
        Xml,

        /// <summary>
        /// Tipo de contenido Json
        /// </summary>
        Json, 

        /// <summary>
        /// Tipo de contenido texto
        /// </summary>
        Text
    }
}
