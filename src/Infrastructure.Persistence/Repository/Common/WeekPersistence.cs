using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class WeekPersistence : RepositoryBase<Week>, IWeekPersistence
{
    public WeekPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<Week[]> GetWeeksAsync(DateTime startDate, DateTime endDate, string copYear) =>
        await DbSet.Where(x => x.WeekStartDate >= startDate && x.WeekEndDate <= endDate && x.CopYear == copYear)
            .ToArrayAsync();

    public async Task<Week[]> GetWeeksAsync(string component, string copYear) =>
        await DbSet.Where(x => x.Component == component && x.CopYear == copYear)
            .ToArrayAsync();
}
