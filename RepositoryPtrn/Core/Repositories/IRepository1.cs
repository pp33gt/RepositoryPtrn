using RepositoryPtrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Core.Repositories
{
    public interface IRepository1
    {
        Repo1Item GetItem(int itemId);
        IEnumerable<Repo1Item> GetAllItems();

        void Add(Repo1Item repo1Item);

    }
}
