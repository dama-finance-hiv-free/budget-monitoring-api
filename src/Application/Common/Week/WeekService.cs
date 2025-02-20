using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.Week;

public class WeekService : ServiceBase<Domain.Entity.Common.Week, WeekVm>, IWeekService
{
    private readonly IWeekPersistence _weekPersistence;
    private readonly IMapper _mapper;

    public WeekService(IMapper mapper, IDistributedCache cache,
        IWeekPersistence weekPersistence) : base(weekPersistence, mapper, cache)
    {
        _weekPersistence = weekPersistence;
        _mapper = mapper;
    }

    public async Task<WeekVm[]> GetWeeksAsync(DateTime startDate, DateTime endDate, string copYear)
    {
        var weeks = await _weekPersistence.GetWeeksAsync(startDate.ToUtcDate(), endDate.ToUtcDate(), copYear);
        foreach (var week in weeks)
        {
            week.WeekSerialAdjusted = week.WeekSerial;
        }
        return _mapper.Map<WeekVm[]>(weeks);
    }

    public async Task<WeekVm[]> GetWeeksAsync(string component, string copYear)
    {
        var weeks = await _weekPersistence.GetWeeksAsync(component, copYear);
        foreach (var week in weeks)
        {
            week.WeekSerialAdjusted = week.WeekSerial;
        }
        return _mapper.Map<WeekVm[]>(weeks);
    }

    public async Task<WeekVm[]> GetWeeksAsync(DateTime startDate, DateTime endDate, DateTime copYearStart)
    {
        //get all dates in the range
        var dateArray = await Task.FromResult(Range(startDate, endDate).ToArray());

        //get the week start and number for each date in range
        var timeWeekNumbers = GetTimeWeekNumbers(dateArray);

        var weeks = timeWeekNumbers.Select(wi => new
        {
            WeekSerial = wi.weekNumber,
            WeekStartDate = GetFirstDateOfWeek(wi.time.Year, wi.weekNumber)
        }).Where(x => dateArray.Contains(x.WeekStartDate)).Distinct().Select(x => new WeekVm
        {
            WeekStartDate = x.WeekStartDate,
            WeekSerial = x.WeekSerial,
            WeekEndDate = x.WeekStartDate.AddDays(6)
        }).ToArray();

        var timeOffset = new DateTimeOffset(copYearStart.Year, 9, 30, 0, 0, 0, TimeSpan.Zero);
        var offsetNumber = GetWeekOfYear(timeOffset.DateTime);

        var offsetNumberCopYear =
            GetWeekOfYear(new DateTime(copYearStart.Year, 12, 31)) - GetWeekOfYear(timeOffset.DateTime);

        foreach (var week in weeks)
        {
            if (week.WeekStartDate.Year == copYearStart.Year)
            {
                week.WeekSerialAdjusted = week.WeekSerial - offsetNumber;
                if (week.WeekSerialAdjusted == 1) week.WeekStartDate = copYearStart;
            }
            else
            {
                week.WeekSerialAdjusted = week.WeekSerial + offsetNumberCopYear;
                if (week.WeekSerialAdjusted == 52) week.WeekEndDate = new DateTime(copYearStart.Year + 1, 9, 30);
            }
        }

        return weeks.ToArray();
    }

    private static IEnumerable<(DateTime time, int weekNumber)> GetTimeWeekNumbers(IEnumerable<DateTime> dateRange) =>
        dateRange.Select(dt => (dt, GetWeekOfYear(dt))).ToArray();

    private static int GetWeekOfYear(DateTime time)
    {
        //var calendar = CultureInfo.InvariantCulture.Calendar;
        //var day = calendar.GetDayOfWeek(time);
        //if (day is > DayOfWeek.Monday and < DayOfWeek.Wednesday) time = time.AddDays(3);

        //return calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        var calendar = CultureInfo.InvariantCulture.Calendar;
        var day = calendar.GetDayOfWeek(time);
        if (day is > DayOfWeek.Wednesday and < DayOfWeek.Friday) time = time.AddDays(3);

        return calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Wednesday);
    }

    private static IEnumerable<DateTime> Range(DateTime startDate, DateTime endDate)
    {
        return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
    }

    private static DateTime GetFirstDateOfWeek(int year, int weekOfYear)
    {
        var jan1 = new DateTime(year, 1, 1);
        var daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

        // Use first Thursday in January to get first week of the year as
        // it will never be in Week 52/53
        var firstThursday = jan1.AddDays(daysOffset);
        var cal = CultureInfo.CurrentCulture.Calendar;
        var firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Wednesday);

        var weekNum = weekOfYear;
        // As we're adding days to a date in Week 1,
        // we need to subtract 1 in order to get the right date for week #1
        if (firstWeek == 1)
        {
            weekNum -= 1;
        }

        // Using the first Thursday as starting week ensures that we are starting in the right year
        // then we add number of weeks multiplied with days
        var result = firstThursday.AddDays(weekNum * 7);

        // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
        return result.AddDays(-3);
    }
}