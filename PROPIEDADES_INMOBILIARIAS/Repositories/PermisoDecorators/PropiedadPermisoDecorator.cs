using PROPIEDADES_INMOBILIARIAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators
{
    public class PropiedadPermisoDecorator : IRepository<Propiedad>
    {
        private readonly IRepository<Propiedad> _repo;

        public PropiedadPermisoDecorator(IRepository<Propiedad> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public IEnumerable<Propiedad> GetAll()
        {
            ValidateSession();

            var propiedades = _repo.GetAll();

            switch (UserSession.Rol)
            {
                case "Cliente":
                    return propiedades.Where(p => p.Estado == EstadoPropiedad.Disponible);

                case "Agente":
                    ValidateAgenteID();
                    return propiedades.Where(p => p.AgenteID == UserSession.AgenteID);

                case "Admin":
                    return propiedades;

                default:
                    throw new UnauthorizedAccessException("Rol no reconocido");
            }
        }

        public void Add(Propiedad entity)
        {
            ValidateAdminAccess();
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            ValidateAdminAccess();
            _repo.Delete(id);
        }

        public Propiedad GetById(int id)
        {
            ValidateSession();

            var propiedad = _repo.GetById(id);

            switch (UserSession.Rol)
            {
                case "Cliente" when propiedad.Estado != EstadoPropiedad.Disponible:
                    throw new UnauthorizedAccessException("Solo propiedades disponibles son visibles para clientes");

                case "Agente":
                    ValidateAgenteID();
                    if (propiedad.AgenteID != UserSession.AgenteID)
                        throw new UnauthorizedAccessException("Propiedad no asignada a este agente");
                    break;
            }

            return propiedad;
        }

        public void Update(Propiedad entity)
        {
            ValidateSession();

            switch (UserSession.Rol)
            {
                case "Cliente":
                    throw new UnauthorizedAccessException("Clientes no pueden modificar propiedades");

                case "Agente":
                    ValidateAgenteID();
                    if (entity.AgenteID != UserSession.AgenteID)
                        throw new UnauthorizedAccessException("No puede modificar propiedades de otros agentes");
                    break;
            }

            _repo.Update(entity);
        }

        #region Helpers
        private void ValidateSession()
        {
            if (string.IsNullOrEmpty(UserSession.Rol))
                throw new UnauthorizedAccessException("Sesión no iniciada");
        }

        private void ValidateAdminAccess()
        {
            ValidateSession();
            if (UserSession.Rol != "Admin")
                throw new UnauthorizedAccessException("Acceso restringido a administradores");
        }

        private void ValidateAgenteID()
        {
            if (!UserSession.AgenteID.HasValue)
                throw new UnauthorizedAccessException("AgenteID no está configurado");
        }
        #endregion
    }
}
