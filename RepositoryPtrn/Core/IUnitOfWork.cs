using RepositoryPtrn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Core
{
    public interface IUnitOfWork
    {
        IRepository1 Repo1 { get; }
        IRepository2 Repo2 { get; }
        Task<int> CompleteAsync();
    }
}
