using System.Data;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Dapper;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class BranchStationPersistence : RepositoryBase<BranchStation>, IBranchStationPersistence
{
    public BranchStationPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<BranchStation>> AddAsync(BranchStation entity)
    {
        var parameters = new DynamicParameters();

        parameters.Add("@p_count", value: 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
        parameters.Add("@p_tenant", value: entity.Tenant);
        parameters.Add("@p_branch", entity.Branch);
        parameters.Add("@p_station", entity.Station);
        parameters.Add("@p_status", entity.Status);
        parameters.Add("@p_created_on", entity.CreatedOn);

        const string sql = "call common.pr_branch_station_add(@p_tenant, @p_branch, @p_station, @p_status, @p_created_on)";

        await Db.ExecuteAsync(sql, parameters);

        var count = parameters.Get<int>("@p_count");

        return count > 0
            ? new RepositoryActionResult<BranchStation>(entity, RepositoryActionStatus.Created)
            : new RepositoryActionResult<BranchStation>(null, RepositoryActionStatus.Error);
    }

    protected override async Task<BranchStation> ItemToGetAsync(string tenant, string branchStation) =>
        await GetFirstOrDefaultAsync(x => x.Station == branchStation);

    protected override async Task<BranchStation> ItemToGetAsync(BranchStation branchStation) =>
        await GetFirstOrDefaultAsync(x => x.Tenant == branchStation.Tenant && x.Branch == branchStation.Branch && x.Station == branchStation.Station);
}