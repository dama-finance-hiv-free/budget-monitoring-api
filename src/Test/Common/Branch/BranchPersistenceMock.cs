using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Helpers;
using Dama.Monitoring.Domain.Contracts.Persistence.Common;
using Moq;

namespace Dama.Monitoring.Application.Test.Common.Branch;

public static class BranchPersistenceMock
{
    public static Mock<IBranchPersistence> GetBranchPersistence()
    {
        var createdDate = DateTime.Now;

        var branches = new List<Domain.Entity.Common.Branch>
        {
            new()
            {
                Tenant = "101",
                Code = "020",
                CreatedOn = createdDate,
            },
            new()
            {
                Tenant = "101",
                Code = "021",
                CreatedOn = createdDate,
            }
        };

        var persistence = new Mock<IBranchPersistence>();
        persistence.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(branches.ToArray);
        
        persistence.Setup(repo => repo.GetBranchCodesAsync())
            .ReturnsAsync(branches.Select(x => x.Code).ToArray);

        persistence.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entity.Common.Branch>()))
            .ReturnsAsync((Domain.Entity.Common.Branch branch) =>
            {
                branches.Add(branch);
                return new RepositoryActionResult<Domain.Entity.Common.Branch>(branch,
                    RepositoryActionStatus.Created);
            });

        return persistence;
    }
}