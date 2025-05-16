using PROPIEDADES_INMOBILIARIAS.Models;
using System;
using System.Collections.Generic;

namespace PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators
{
    public class ClientePermisoDecorator : IRepository<Cliente>
    {
        private readonly IRepository<Cliente> _repo;

        public ClientePermisoDecorator(IRepository<Cliente> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Cliente> GetAll()
        {
            if (UserSession.Rol == "Cliente")
                throw new UnauthorizedAccessException("Clientes no pueden ver otros clientes");

            return _repo.GetAll();
        }

        public void Add(Cliente entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id); 
        }

        public Cliente GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Update(Cliente entity)
        {
            _repo.Update(entity);
        }
    }
}
