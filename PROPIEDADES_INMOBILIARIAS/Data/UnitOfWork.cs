using System;
using System.Configuration;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Repositories;
using PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators;
using PROPIEDADES_INMOBILIARIAS.Strategies;


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

    public AuthRepository Autenticacion { get; }

    public UnitOfWork(
        IZonaStrategy zonaStrategy = null,
        bool habilitarPermisos = true
    )
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RealEstateDB"].ConnectionString;
        _connection = new SqlConnection(connectionString);
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

    public SqlConnection GetConnection()
    {
        return _connection;
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
        if (_connection?.State == System.Data.ConnectionState.Open)
            _connection.Close();
        _connection?.Dispose();
    }
}
