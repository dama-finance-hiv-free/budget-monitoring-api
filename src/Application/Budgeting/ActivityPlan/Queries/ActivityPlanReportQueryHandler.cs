using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Report;
using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries
{
    public class ActivityPlanReportQueryHandler : RequestHandlerBase, IRequestHandler<ActivityPlanReportQuery, ReportFileVm>
    {
        private readonly IActivityPlanService _activityPlanService;
        private readonly IActivityPlanReport _activityPlanReport;
        private readonly IMapper _mapper;

        public ActivityPlanReportQueryHandler(IMapper mapper, IActivityPlanService activityPlanService, IActivityPlanReport activityPlanReport)
        {
            _activityPlanService = activityPlanService;
            _activityPlanReport = activityPlanReport;
            _mapper = mapper;
        }

        public async Task<ActivityPlanVm> Handle(ActivityPlanQuery request, CancellationToken cancellationToken) =>
            await _activityPlanService.GetAsync(request.Tenant, request.Code);

        public async Task<ReportFileVm> Handle(ActivityPlanReportQuery request, CancellationToken cancellationToken)
        {
            var activityPlans = _mapper.Map<List<ActivityPlanVm>>(await _activityPlanService.GetActivityPlansAsync(request.Tenant));

            var data = _activityPlanReport.Generate(activityPlans);

            if (data is null)
            {
                return null;
            }

            var activityPlanExportFileDto = new ReportFileVm()
            {
                ContentType = "application/pdf",
                Data = data,
                FileName = $"{Guid.NewGuid()}.pdf"
            };

            return activityPlanExportFileDto;
        }
    }
}