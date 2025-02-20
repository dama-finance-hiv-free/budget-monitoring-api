using System;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Batch;

namespace Dama.Fin.Domain.Contracts.Service.Batch;

public interface ISessionBatchService: IDisposable
{
    Task<SessionBatchVm> GetServerStatusBatchAsync(string tenant, string user, string branchCode, string lid);
}