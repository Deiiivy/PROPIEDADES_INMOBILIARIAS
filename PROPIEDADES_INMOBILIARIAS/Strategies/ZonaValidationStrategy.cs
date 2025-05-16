using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Strategies
{
    public class ZonaValidationStrategy : IZonaStrategy
    {
        public bool ValidarZonaAgente(string zonaPropiedad, string zonaAgente)
        {
         
            return zonaPropiedad.Equals(zonaAgente, StringComparison.OrdinalIgnoreCase);
        }
    }
}
