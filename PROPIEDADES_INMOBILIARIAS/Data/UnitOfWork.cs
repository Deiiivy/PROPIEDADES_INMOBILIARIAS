﻿using System;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Repositories;
using PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators;
using PROPIEDADES_INMOBILIARIAS.Strategies;

namespace PROPIEDADES_INMOBILIARIAS.Data
{
    public class UnitOfWork : IDisposable
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;

       
        public PropiedadRepository Propiedades { get; }
        public ClienteRepository Clientes { get; }
        public AgenteRepository Agentes { get; }
        public VisitaRepository Visitas { get; }
        public TransaccionRepository Transacciones { get; }

      
        public IRepository<Propiedad> PropiedadesSeguras { get; }
        public IRepository<Cliente> ClientesSeguros { get; }

        // Autenticación
        public AuthRepository Autenticacion { get; }

        public UnitOfWork(
            IZonaStrategy zonaStrategy = null,
            bool habilitarPermisos = true
        )
        {
            _connection = DatabaseConnection.Instance.GetConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            
            Propiedades = new PropiedadRepository(_connection, _transaction);
            Clientes = new ClienteRepository(_connection, _transaction);
            Agentes = new AgenteRepository(_connection, _transaction, zonaStrategy);
            Visitas = new VisitaRepository(_connection, _transaction);
            Transacciones = new TransaccionRepository(_connection, _transaction);

           
            Autenticacion = new AuthRepository(_connection);

           
            if (habilitarPermisos)
            {
                PropiedadesSeguras = new PropiedadPermisoDecorator(Propiedades);
                ClientesSeguros = new ClientePermisoDecorator(Clientes);
            }
            else
            {
                PropiedadesSeguras = Propiedades;
                ClientesSeguros = Clientes;
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
