using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPIEDADES_INMOBILIARIAS.Models;

namespace PROPIEDADES_INMOBILIARIAS.Factories
{
    public interface IVisitaFactory
    {
        Visita CrearVisita(int propiedadId, int clienteId, int agenteId, DateTime fecha, TimeSpan hora);
    }
}

