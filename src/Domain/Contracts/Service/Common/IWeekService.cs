using System;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IWeekService : IServiceBase<WeekVm>
{
    Task<WeekVm[]> GetWeeksAsync(DateTime startDate, DateTime endDate, string copYear);
    Task<WeekVm[]> GetWeeksAsync(DateTime startDate, DateTime endDate, DateTime copYearStart);
    Task<WeekVm[]> GetWeeksAsync(string component, string copYear);
}