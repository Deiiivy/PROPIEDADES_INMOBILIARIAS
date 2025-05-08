using PROPIEDADES_INMOBILIARIAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public interface IPropiedadRepository
    {
        void AgregarPropiedad(Propiedad propiedad);
        void ActualizarPropiedad(Propiedad propiedad);
        void EliminarPropiedad(int propiedadId);
        List<Propiedad> ObtenerPropiedades();
    }

}
