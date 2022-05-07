using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.ENTITY
{
    /// <summary>
    /// clase catalogo submarca contiene las propiedes nesesarioas para la recoleccion de datos
    /// </summary>
    [DataContract]
    public class CatSubMarca
    {
        /// <summary>
        /// propiedad que tiene la resposablidada de contener el valor de IdSubMarca
        /// </summary>
        [DataMember(Name ="iIdSubMarca")]
        public int IdSubMarca { get; set; }
        /// <summary>
        ///  propiedad que tiene la resposablidada de contener el valor de IdMarcaSubramo
        /// </summary>
        [DataMember(Name = "iIdMarcaSubramo")]
        public int IdMarcaSubramo { get;set;}
        /// <summary>
        /// propiedad que tiene la resposablidada de contener el valor de IdMostrar
        /// </summary>
        [DataMember(Name = "iIdMostrar")]
        public int IdMostrar { get; set; }
        /// <summary>
        /// ropiedad que tiene la resposablidada de contener el valor de SubMarca
        /// </summary>
        [DataMember(Name = "sSubMarca")]
        public string SubMarca { get; set; }
    }
}
