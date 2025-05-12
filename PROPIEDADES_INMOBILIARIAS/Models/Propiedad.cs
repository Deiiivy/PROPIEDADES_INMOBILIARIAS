using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Propiedad
    {
        public string Zona { get; set; }
        // Identificador único de la propiedad (PK en la base de datos)
        public int PropiedadID { get; set; }

        // Dirección física de la propiedad
        public string Direccion { get; set; }

        // Tipo de propiedad (usamos el enum TipoPropiedad)
        public TipoPropiedad Tipo { get; set; }

        // Tamaño en metros cuadrados
        public double Superficie { get; set; }

        // Precio en dólares
        public decimal Precio { get; set; }

        // Estado actual (usamos el enum EstadoPropiedad)
        public EstadoPropiedad Estado { get; set; }

        // ID del agente asignado (FK a la tabla Agentes)
        public int AgenteID { get; set; }


    }
}

