using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IWeekPersistence : IDataPersistence<Week>
{
    Task<Week[]> GetWeeksAsync(DateTime startDate, DateTime endDate, string copYear);
    Task<Week[]> GetWeeksAsync(string component, string copYear);
}