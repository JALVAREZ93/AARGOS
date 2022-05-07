using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.ENTITY
{
    [DataContract]
    public class CatModelo
    {
        [DataMember(Name = "iIdModelo")]
        public int IdModelo { get; set; }
        [DataMember(Name = "sModelo")]
        public string Modelo{ get; set; }
    }
}
