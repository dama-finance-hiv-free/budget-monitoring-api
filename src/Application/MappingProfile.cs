using AutoMapper;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Entity.Common;
using Dama.Fin.Domain.Vm.Budgeting;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Budgeting
        CreateMap<Activity, ActivityVm>().ReverseMap();
        CreateMap<ActivityHistory, ActivityVm>().ReverseMap();
        CreateMap<ActivityPlan, ActivityPlanVm>().ReverseMap();
        CreateMap<Budget, BudgetVm>().ReverseMap();
        CreateMap<BudgetCode, BudgetCodeVm>().ReverseMap();
        CreateMap<BudgetHistory, BudgetVm>().ReverseMap();
        CreateMap<Component, ComponentVm>().ReverseMap();
        CreateMap<CopYear, CopYearVm>().ReverseMap();
        CreateMap<CopYearBudgetCode, CopYearBudgetCodeVm>().ReverseMap();
        CreateMap<CopYearCostCategory, CopYearCostCategoryVm>().ReverseMap();
        CreateMap<CopYearIntervention, CopYearInterventionVm>().ReverseMap();
        CreateMap<CostCategory, CostCategoryVm>().ReverseMap();
        CreateMap<District, DistrictVm>().ReverseMap();
        CreateMap<Intervention, InterventionVm>().ReverseMap();
        CreateMap<Milestone, MilestoneVm>().ReverseMap();
        CreateMap<Project, ProjectVm>().ReverseMap();
        CreateMap<ProjectSite, ProjectSiteVm>().ReverseMap();
        CreateMap<Quarter, QuarterVm>().ReverseMap();
        CreateMap<Region, RegionVm>().ReverseMap();
        CreateMap<Runner, RunnerVm>().ReverseMap();
        CreateMap<RunnerHistory, RunnerHistoryVm>().ReverseMap();
        CreateMap<RunnerComponent, RunnerComponentVm>().ReverseMap();
        CreateMap<RunnerPeriod, RunnerPeriodVm>().ReverseMap();
        CreateMap<RunnerStatus, RunnerStatusVm>().ReverseMap();
        CreateMap<Site, SiteVm>().ReverseMap();
        CreateMap<SiteType, SiteTypeVm>().ReverseMap();
        CreateMap<Strategy, StrategyVm>().ReverseMap();
        CreateMap<SurgeActivity, SurgeActivityVm>().ReverseMap();
        CreateMap<TransactionCode, TransactionCodeVm>().ReverseMap();
        CreateMap<Target, TargetVm>().ReverseMap();
        CreateMap<UserCoordination, UserCoordinationVm>().ReverseMap();
        CreateMap<Zone, ZoneVm>().ReverseMap();
        CreateMap<RunnerPeriodHistory, RunnerPeriodHistoryVm>().ReverseMap();
        CreateMap<Week, WeekVm>().ReverseMap();
        CreateMap<PrintDailyData, DailyDataVm>().ReverseMap();


        //Common
        CreateMap<Branch, BranchVm>().ReverseMap();
        CreateMap<BranchStation, BranchStationVm>().ReverseMap();
        CreateMap<DateGeneration, DateGenerationVm>().ReverseMap();
        CreateMap<DateGenerationHistory, DateGenerationHistoryVm>().ReverseMap();
        CreateMap<DialogMessage, DialogMessageVm>().ReverseMap();
        CreateMap<Employer, EmployerVm>().ReverseMap();
        CreateMap<MonthName, MonthNameVm>().ReverseMap();
        CreateMap<Privilege, PrivilegeVm>().ReverseMap();
        CreateMap<Role, RoleVm>().ReverseMap();
        CreateMap<RoleMenu, RoleMenuVm>().ReverseMap();
        CreateMap<ServerStatus, ServerStatusVm>().ReverseMap();
        CreateMap<ServerStatusHistory, ServerStatusHistoryVm>().ReverseMap();
        CreateMap<SystemMenu, SystemMenuVm>().ReverseMap();
        CreateMap<Tenant, TenantVm>().ReverseMap();
        CreateMap<Town, TownVm>().ReverseMap();
        CreateMap<User, UserVm>().ReverseMap();
        CreateMap<UserBranch, UserBranchVm>().ReverseMap();
        CreateMap<UserRole, UserRoleVm>().ReverseMap();
        CreateMap<TicketStatus, TicketStatusVm>().ReverseMap();
        CreateMap<Ticket, TicketVm>().ReverseMap();
    }
}