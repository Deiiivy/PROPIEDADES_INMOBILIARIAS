using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    // Estados  de una propiedad
    public enum EstadoPropiedad
    {
        Disponible,
        EnProcesoVenta,
        Vendida
    }

    // Tipos de propiedades disponibles
    public enum TipoPropiedad
    {
        Apartamento,
        Casa,
        Oficina
    }
}

