using System;
using System.Data;
using Dama.Core.Common.Core;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Dama.Fin.Infrastructure.Persistence;

public class DatabaseFactory : Disposable, IDatabaseFactory
{
    public DatabaseFactory(MonitoringContext dataContext)
    {
        _dataContext = dataContext;
        _db = new NpgsqlConnection(GetContext().Database.GetDbConnection().ConnectionString);
    }

    private MonitoringContext _dataContext;
    private readonly IDbConnection _db;

    public MonitoringContext GetContext()
    {
        return _dataContext;
    }

    public IDbConnection GetConnection()
    {
        return _db;
    }

    protected override void DisposeCore()
    {
        _dataContext?.Dispose();
        _dataContext = null;
    }
}

public interface IDatabaseFactory : IDisposable
{
    MonitoringContext GetContext();
    IDbConnection GetConnection();
}