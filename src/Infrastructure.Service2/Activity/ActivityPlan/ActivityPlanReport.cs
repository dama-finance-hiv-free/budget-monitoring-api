using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using AspNetCore.Reporting;
using Dama.Monitoring.Domain.Contracts.Service.Report;
using Dama.Monitoring.Domain.Vm.Budgeting;
using Microsoft.AspNetCore.Hosting;

namespace Dama.Monitoring.Infrastructure.Reporting.Activity.ActivityPlan
{
    public class ActivityPlanReport: IActivityPlanReport
    { 
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActivityPlanReport(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] Generate(ActivityPlanVm[] activityPlans, Dictionary<string, string> parameters)
        {
            try
            {
                if (activityPlans == null) return null;
                var dt = GetActivityPlanDataTable(activityPlans);
                const int extension = 1;

                string[] paths = { _webHostEnvironment.WebRootPath, "reports", "activity_plan_1.rdl" };
                var fullPath = Path.Combine(paths);

                var lr = new LocalReport(fullPath);
                lr.AddDataSource("ActivityPlanData", dt);
                var result = lr.Execute(RenderType.Pdf, extension, parameters);

                return result.MainStream;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        private static DataTable GetActivityPlanDataTable(IEnumerable<ActivityPlanVm> activityPlans)
        {
            var table = new DataTable();

            table.Columns.Add("Tenant", typeof(string));
            table.Columns.Add("Code", typeof(string));
            table.Columns.Add("Description", typeof(string));

<<<<<<< HEAD:src/Infrastructure.Service/Activity/ActivityPlan/ActivityPlanReport.cs
            activityPlans.CopyToDataTable(table, LoadOption.PreserveChanges);
=======
            var query = activityPlans.Where(x => x.ActivityType == "01");

            query.CopyToDataTable(table, LoadOption.PreserveChanges);
>>>>>>> db595dfdb5b63fee8d101f0a795811ac02a98e09:src/Infrastructure.Service2/Activity/ActivityPlan/ActivityPlanReport.cs

            return table;
        }
    }


}
