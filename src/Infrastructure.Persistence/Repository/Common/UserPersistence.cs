using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class UserPersistence : RepositoryBase<User>, IUserPersistence
{
    public UserPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<User>> AddAsync(User entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastUser = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastUser == null
                ? "1".ToTwoChar()
                : (lastUser.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<User>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<User>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<User>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RepositoryActionResult<User>> ConnectUserAsync(User user)
    {
        var connect = await ItemToGetAsync(user);
        connect.Connected = user.Connected;
        connect.Computer = user.Computer;
        connect.LogTime = user.LogTime;
        connect.DeviceSerial = user.DeviceSerial;

        return await EditAsync(connect);
    }

    public async Task<RepositoryActionResult<User>> DisconnectUsersAsync(User user)
    {
        var disconnect = await ItemToGetAsync(user);
        disconnect.Code = user.Code;
        disconnect.Connected = user.Connected;
        disconnect.Computer = user.Computer;
        disconnect.LogTime = user.LogTime;
        disconnect.DeviceSerial = user.DeviceSerial;

        return await EditAsync(disconnect);
    }

    public async Task DisconnectUsersAsync(User[] users)
    {
        foreach (var user in users) await DisconnectUsersAsync(user);
    }

    public async Task<User[]> GetConnectedUsersAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant && x.Connected == "01");

    protected override async Task<User> ItemToGetAsync(string tenant, string code) =>
        await GetFirstOrDefaultAsync(x => x.Tenant == tenant && x.Code == code);

    protected override async Task<User> ItemToGetAsync(User user) =>
        await GetFirstOrDefaultAsync(x => x.Tenant == user.Tenant && x.Code == user.Code);
}