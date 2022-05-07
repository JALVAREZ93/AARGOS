using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AARGOS.ENTITY
{
    public class Estado
    {
        [JsonProperty("iIdEstado")]
        public int IdEstado { get; set; }

        [JsonProperty("Pais")]
        public string Pais { get; set; }

        [JsonProperty("iEstadoPais")]
        public int EstadoPais { get; set; }

        [JsonProperty("iClaveEstadoCepomex")]
        public int ClaveEstadoCepomex { get; set; }

        [JsonProperty("sEstado")]
        public string EstadoName { get; set; }
    }

    public class Municipio
    {
        [JsonProperty("iIdMunicipio")]
        public int IdMunicipio { get; set; }

        [JsonProperty("Estado")]
        public Estado Estado { get; set; }

        [JsonProperty("iMunicipioEstado")]
        public int MunicipioEstado { get; set; }

        [JsonProperty("iClaveMunicipioCepomex")]
        public int ClaveMunicipioCepomex { get; set; }

        [JsonProperty("sMunicipio")]
        public string MunicipioName { get; set; }
    }

    public class CatSepomex
    {
        [JsonProperty("Municipio")]
        public Municipio Municipio { get; set; }

        [JsonProperty("Ubicacion")]
        public List<Ubicacion> Ubicacion { get; set; }
    }

    public class Ubicacion
    {
        [JsonProperty("iIdUbicacion")]
        public int IdUbicacion { get; set; }

        [JsonProperty("CodigoPostal")]
        public string CodigoPostal { get; set; }

        [JsonProperty("iUbicacionCodigoPostal")]
        public int UbicacionCodigoPostal { get; set; }

        [JsonProperty("TipoUbicacion")]
        public string TipoUbicacion { get; set; }

        [JsonProperty("iClaveUbicacionCepomex")]
        public int ClaveUbicacionCepomex { get; set; }

        [JsonProperty("Ciudad")]
        public string Ciudad { get; set; }

        [JsonProperty("sUbicacion")]
        public string UbicacionName { get; set; }
    }

}
