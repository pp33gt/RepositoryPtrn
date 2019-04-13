using RepositoryPtrn.Core;
using RepositoryPtrn.Core.Repositories;
using RepositoryPtrn.Models;
using RepositoryPtrn.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly RepositoryPtrnContext _context;

        public IRepository1 Repo1 { get; private set; }
        public IRepository2 Repo2 { get; private set; }

        public UnitOfWork(RepositoryPtrnContext context)
        {
            _context = context;
            Repo1 = new Repository1(context);
            Repo2 = new Repository2(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
