using System;
using System.Collections.Generic;
using System.Linq;
using AARGOS.DATOS;
using AARGOS.ENTITY;
namespace AARGOS.BL
{
    public class Filtro
    {
        readonly DatosCatalogo datosCatalogo = new DatosCatalogo();

        public IEnumerable<CatMarca> LstMarcas()
        {
            return datosCatalogo.ObtenerMarcas();
        }

        public IEnumerable<CatSubMarca> LstSubMarcas(int idMarca)
        {
            return datosCatalogo.ObtenerSubmarcas(idMarca);
        }
        public IEnumerable<CatModelo> Modelo(int idSubmarca)
        {
            return datosCatalogo.ObtenerModelos(idSubmarca);
            
        }

        public IEnumerable<CatModeloDescripcion> lstDescriptions(int idModelo)
        {
            return datosCatalogo.ObtenerDescripcionModelos(idModelo);
          
        }

        public List<CatGenero> Generos()
        {
            List<CatGenero> catGeneros = new List<CatGenero>();
            catGeneros.Add(new CatGenero { Id = 1, Genero = "Maculino" });
            catGeneros.Add(new CatGenero { Id = 2, Genero = "Femenino" });
            return catGeneros;
        }
     
        
        public CatDomicilio domicilio(int cp)
        {            
            var listaDireccion = datosCatalogo.ObtenerDireccion(cp);

            return new CatDomicilio
            {
                Estado = listaDireccion?.FirstOrDefault().Municipio.Estado.EstadoName,
                Municipio = listaDireccion?.FirstOrDefault().Municipio.MunicipioName,
                Colonia = listaDireccion?.FirstOrDefault().Ubicacion.FirstOrDefault().UbicacionName
            };
        }
    }

    }

