using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dama.Fin.Infrastructure.Persistence;

public class MonitoringContext : DbContext
{
    private readonly IConfiguration  _configuration;

    public MonitoringContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    #region DbSets

    #region Budgeting

    public virtual DbSet<Activity> ActivitySet { get; set; }
    public virtual DbSet<ActivityHistory> ActivityHistorySet { get; set; }
    public virtual DbSet<ActivityPlan> ActivityPlanSet { get; set; }
    public virtual DbSet<ActivityPlanHistory> ActivityPlanHistorySet { get; set; }
    public virtual DbSet<AnnualTarget> AnnualTargetSet { get; set; }
    public virtual DbSet<Budget> BudgetSet { get; set; }
    public virtual DbSet<BudgetCode> BudgetCodeSet { get; set; }
    public virtual DbSet<BudgetHistory> BudgetHistorySet { get; set; }
    public virtual DbSet<Component> ComponentSet { get; set; }
    public virtual DbSet<ComponentActivity> ComponentActivitySet { get; set; }
    public virtual DbSet<CopYear> CopYearSet { get; set; }
    public virtual DbSet<CopYearBudgetCode> CopYearBudgetCodeSet { get; set; }
    public virtual DbSet<CopYearCostCategory> CopYearCostCategorySet { get; set; }
    public virtual DbSet<CopYearOutlay> CopYearOutlaySet { get; set; }
    public virtual DbSet<District> DistrictSet { get; set; }
    public virtual DbSet<Intervention> InterventionSet { get; set; }
    public virtual DbSet<Milestone> MilestoneSet { get; set; }
    public virtual DbSet<Outlay> OutlaySet { get; set; }
    public virtual DbSet<OutlayIntervention> OutlayInterventionSet { get; set; }
    public virtual DbSet<Project> ProjectSet { get; set; }
    public virtual DbSet<Quarter> QuarterSet { get; set; }
    public virtual DbSet<Region> RegionSet { get; set; }
    public virtual DbSet<RegionRunnerPeriod> RegionRunnerPeriodSet { get; set; }
    public virtual DbSet<Runner> RunnerSet { get; set; }
    public virtual DbSet<RunnerComponent> RunnerComponentSet { get; set; }
    public virtual DbSet<RunnerComponentHistory> RunnerComponentHistorySet { get; set; }
    public virtual DbSet<RunnerHistory> RunnerHistorySet { get; set; }
    public virtual DbSet<RunnerPeriod> RunnerPeriodSet { get; set; }
    public virtual DbSet<RunnerPeriodComponent> RunnerPeriodComponentSet { get; set; }
    public virtual DbSet<RunnerPeriodComponentHistory> RunnerPeriodComponentHistorySet { get; set; }
    public virtual DbSet<RunnerPeriodHistory> RunnerPeriodHistorySet { get; set; }
    public virtual DbSet<RunnerPeriodStatus> RunnerPeriodStatusSet { get; set; }
    public virtual DbSet<Site> SiteSet { get; set; }
    public virtual DbSet<SiteType> SiteTypeSet { get; set; }
    public virtual DbSet<Strategy> StrategySet { get; set; }
    public virtual DbSet<Target> TargetSet { get; set; }
    public virtual DbSet<TargetHistory> TargetHistorySet { get; set; }
    public virtual DbSet<TransactionCode> TransactionCodeSet { get; set; }
    public virtual DbSet<UserCoordination> UserCoordinationSet { get; set; }
    public virtual DbSet<Zone> ZoneSet { get; set; }
    public virtual DbSet<PrintDailyData> PrintDailyDataSet { get; set; }



    #endregion

    #region Common

    public virtual DbSet<Branch> BranchSet { get; set; }
    public virtual DbSet<Employer> EmployerSet { get; set; }
    public virtual DbSet<BranchStation> BranchStationSet { get; set; }
    public virtual DbSet<DateGeneration> DateGenerationSet { get; set; }
    public virtual DbSet<DialogMessage> DialogMessageSet { get; set; }
    public virtual DbSet<MonthName> MonthNameSet { get; set; }
    public virtual DbSet<Privilege> PrivilegeSet { get; set; }
    public virtual DbSet<Role> RoleSet { get; set; }
    public virtual DbSet<RoleMenu> RoleMenuSet { get; set; }
    public virtual DbSet<DateGenerationHistory> DateGenerationHistorySet { get; set; }
    public virtual DbSet<ServerStatus> ServerStatusSet { get; set; }
    public virtual DbSet<ServerStatusHistory> ServerStatusHistorySet { get; set; }
    public virtual DbSet<SystemMenu> SystemMenuSet { get; set; }
    public virtual DbSet<Tenant> TenantSet { get; set; }
    public virtual DbSet<Town> TownSet { get; set; }
    public virtual DbSet<User> UserSet { get; set; }
    public virtual DbSet<UserBranch> UserBranchSet { get; set; }
    public virtual DbSet<UserRole> UserRoleSet { get; set; }
    public virtual DbSet<Ticket> TicketSet { get; set; }
    public virtual DbSet<TicketStatus> TicketStatusSet { get; set; }

    #endregion

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<IIdentifiableEntity>();

        modelBuilder.AddCommonConfigurations();
        modelBuilder.AddBudgetingConfigurations();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        var connectionString = _configuration["ConnectionStrings:MonitoringData"];
        optionsBuilder.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }
}