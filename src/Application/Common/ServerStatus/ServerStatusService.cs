using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.ServerStatus;

public class ServerStatusService : ServiceBase<Domain.Entity.Common.ServerStatus, ServerStatusVm>,
    IServerStatusService
{
    private readonly IServerStatusPersistence _serverStatusPersistence;
    private readonly IMapper _mapper;

    public ServerStatusService(IDataPersistence<Domain.Entity.Common.ServerStatus> persistence, IMapper mapper,
        IDistributedCache cache, IServerStatusPersistence serverStatusPersistence) : base(persistence, mapper, cache)
    {
        _serverStatusPersistence = serverStatusPersistence;
        _mapper = mapper;
    }

    public async Task<ServerStatusVm> GetServerStatusAsync(string tenant, string branch)
    {
        var serverStatus = await _serverStatusPersistence.GetServerStatusAsync(new Domain.Entity.Common.ServerStatus
        {
            Tenant = tenant,
        });
        return _mapper.Map<ServerStatusVm>(serverStatus);
    }

    public async Task<ServerStatusVm[]> GetServerStatusesAsync(string tenant)
    {
        var serverStatuses = await _serverStatusPersistence.GetServerStatusesAsync(tenant);
        return _mapper.Map<ServerStatusVm[]>(serverStatuses);
    }
}