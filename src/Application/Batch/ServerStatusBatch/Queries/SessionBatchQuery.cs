using Dama.Fin.Domain.Vm.Batch;
using MediatR;

namespace Dama.Fin.Application.Batch.ServerStatusBatch.Queries;

public class SessionBatchQuery : IRequest<SessionBatchVm>
{
    public string Tenant { get; set; }
    public string User { get; set; }
    public string Language { get; set; }
    public string Branch { get; set; }
}