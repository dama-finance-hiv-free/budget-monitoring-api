using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class DialogMessagePersistence : RepositoryBase<DialogMessage>, IDialogMessagePersistence
{
    public DialogMessagePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }
}
