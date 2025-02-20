using Dama.Fin.Domain.Contracts.Service.Batch;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Common;
using System;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Batch;

namespace Dama.Fin.Application.Batch;

public class SessionBatchService : ServiceBase, ISessionBatchService
{
    private readonly IBranchService _branchService;
    private readonly IServerStatusService _serverStatusService;
    private readonly IUserBranchService _userBranchService;
    private readonly IUserMenuService _userMenuService;
    private readonly IRegionService _regionService;
    private readonly IRunnerService _runnerService;
    private readonly IRunnerComponentService _runnerComponentService;

    public SessionBatchService(IBranchService branchService, IServerStatusService serverStatusService,
        IUserBranchService userBranchService, IUserMenuService userMenuService, IRegionService regionService,
        IRunnerService runnerService, IRunnerComponentService runnerComponentService)
    {
        _branchService = branchService;
        _serverStatusService = serverStatusService;
        _userBranchService = userBranchService;
        _userMenuService = userMenuService;
        _regionService = regionService;
        _runnerService = runnerService;
        _runnerComponentService = runnerComponentService;
    }

    public async Task<SessionBatchVm> GetServerStatusBatchAsync(string tenant, string user, string branchCode, string lid)
    {
        if (string.IsNullOrEmpty(tenant))
            throw new ArgumentNullException(tenant, "tenant can not be null");
        if (string.IsNullOrEmpty(user))
            throw new ArgumentNullException(user, "user can not be null");
        if (string.IsNullOrEmpty(lid))
            lid = "01";

        var regions = await _regionService.GetRegionsAsync();
        var branches = await _branchService.GetUserBranchesAsync(tenant, user);
        var serverStatuses = await _serverStatusService.GetServerStatusesAsync(tenant);
        var userMenus = await _userMenuService.GetUserMenuCodesAsync(tenant, user, lid);
        var runners = await _runnerService.GetRunnersAsync(tenant);
        var runnerComponents = await _runnerComponentService.GetRunnerComponentsAsync(tenant);
        
        var defaultBranch = await _userBranchService.GetUserDefaultBranchAsync(tenant, user);

        var branch = string.Empty;
        if (string.IsNullOrEmpty(branchCode))
        {
            if (branches is { Length: > 0 })
                branch = defaultBranch ?? branches[0].Code;
        }
        else
        {
            branch = branchCode;
        }


        return new SessionBatchVm
        {
            Regions = regions,
            Tenant = tenant,
            Branch = branch,
            Branches = branches,
            ServerStatuses = serverStatuses,
            UserMenus = userMenus,
            Runners = runners,
            RunnerComponents = runnerComponents,
            UserCode = user
        };
    }
}