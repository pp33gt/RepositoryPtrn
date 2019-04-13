using RepositoryPtrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Core.Repositories
{
    public interface IRepository2
    {
        Repo2Item GetItem(int itemId);

        IEnumerable<Repo2Item> GetAllItems();

        void Add(Repo2Item repo2Item);
    }
}
