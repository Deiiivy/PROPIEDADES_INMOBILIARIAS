using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPIEDADES_INMOBILIARIAS.Models;

namespace PROPIEDADES_INMOBILIARIAS.Factories
{
    public interface ITransaccionFactory
    {
        Transaccion CrearTransaccion(int propiedadId, int clienteId, decimal monto);
    }
}

