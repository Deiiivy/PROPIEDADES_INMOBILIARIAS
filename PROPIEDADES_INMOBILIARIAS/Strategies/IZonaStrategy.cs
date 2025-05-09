using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Strategies
{
    public interface IZonaStrategy
    {
        bool ValidarZonaAgente(string zonaPropiedad, string zonaAgente);
    }
}
