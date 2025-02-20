using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.Fin.Infrastructure.Persistence.Configuration.Common;

public class ServerStatusConfiguration : ServerStatusBaseConfiguration<ServerStatus>
{
    public override void Configure(EntityTypeBuilder<ServerStatus> entity)
    {
        base.Configure(entity);

        entity.ToTable("server_status", "common");
    }
}