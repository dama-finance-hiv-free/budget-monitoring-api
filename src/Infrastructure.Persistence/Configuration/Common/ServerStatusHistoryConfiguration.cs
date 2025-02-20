using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class ServerStatusHistoryConfiguration : ServerStatusBaseConfiguration<ServerStatusHistory>
{
    public override void Configure(EntityTypeBuilder<ServerStatusHistory> entity)
    {
        base.Configure(entity);

        entity.ToTable("server_status_history", "common");
    }
}