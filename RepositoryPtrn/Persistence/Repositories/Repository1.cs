using RepositoryPtrn.Core.Repositories;
using RepositoryPtrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Persistence.Repositories
{
    public class Repository1 : IRepository1
    {

        private readonly IRepositoryPtrnContext _context;

        public Repository1(IRepositoryPtrnContext context)
        {
            _context = context;
        }

        public Repo1Item GetItem(int id)
        {
            return _context.Repo1Items.Where(a => a.Id == id).SingleOrDefault();
        }

        public IEnumerable<Repo1Item> GetAllItems()
        {
            return _context.Repo1Items.ToList();
        }

        public void Add(Repo1Item repo1Item)
        {
            _context.Repo1Items.Add(repo1Item);
        }

    }
}
