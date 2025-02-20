using Dama.Core.Common.Contracts;
using Dama.Core.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence;

public abstract class RepositoryBase<TEntity> :  RepositoryBase<TEntity, MonitoringContext>
    where TEntity : class, IIdentifiableEntity, new()
{
    protected IDatabaseFactory DatabaseFactory;
    protected string ConnectionString;

    protected RepositoryBase(IDatabaseFactory databaseFactory) : base(databaseFactory.GetContext())
    {
        DatabaseFactory = databaseFactory;
        Db = databaseFactory.GetConnection();
        ConnectionString = DatabaseFactory.GetContext().Database.GetDbConnection().ConnectionString;
    }
}