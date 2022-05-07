using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.ENTITY
{
    [DataContract]
    public class CatMarca
    {
        /// <summary>
        /// propiedad tipo int que tiene la responsabiliad de contener el identificador de la marca
        /// </summary>
        [DataMember(Name ="iIdMarca")]
        public int IdMarca { get; set; }

        /// <summary>
        /// Propiedad String que tiene la resposabiliad de contener la marca
        /// </summary>
        [DataMember(Name = "sMarca")]
        public string Marca { get; set; }
    }
}
