using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.ENTITY
{
    [DataContract]
    public class CatModeloDescripcion
    {
        [DataMember(Name = "iIdDescripcionModelo")]
        public int IdDescripcionModelo { get; set; }
        [DataMember(Name = "iIdModeloSubmarca")]
        public int iIdModeloSubmarca { get; set; }
        [DataMember(Name = "iIdMostrar")]
        public int IdMostrar { get; set; }
        [DataMember(Name = "sDescripcion")]
        public string Descripcion { get; set; }
    }
}

