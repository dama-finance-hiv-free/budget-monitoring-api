﻿using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerPeriodHistoryPersistence : RepositoryBase<RunnerPeriodHistory>, IRunnerPeriodHistoryPersistence
{
    public RunnerPeriodHistoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<RunnerPeriodHistory>> AddAsync(RunnerPeriodHistory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRunnerPeriodHistory = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastRunnerPeriodHistory == null
                ? "1".ToTwoChar()
                : (lastRunnerPeriodHistory.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<RunnerPeriodHistory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RunnerPeriodHistory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RunnerPeriodHistory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RunnerPeriodHistory[]> GetRunnerPeriodHistoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RunnerPeriodHistory> ItemToGetAsync(string tenant, string runnerPeriodHistory) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerPeriodHistory);

    protected override async Task<RunnerPeriodHistory> ItemToGetAsync(RunnerPeriodHistory runnerPeriodHistory) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerPeriodHistory.Code);
}