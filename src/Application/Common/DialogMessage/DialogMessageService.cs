using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.DialogMessage;

public class DialogMessageService : ServiceBase<Domain.Entity.Common.DialogMessage, DialogMessageVm>, IDialogMessageService
{
    public DialogMessageService(IDataPersistence<Domain.Entity.Common.DialogMessage> persistence, IMapper mapper,
        IDistributedCache cache) : base(persistence, mapper, cache)
    {
    }
}