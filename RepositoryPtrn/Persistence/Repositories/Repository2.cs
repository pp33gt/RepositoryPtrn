using RepositoryPtrn.Core.Repositories;
using RepositoryPtrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Persistence.Repositories
{
    public class Repository2 : IRepository2
    {

        private readonly IRepositoryPtrnContext _context;

        public Repository2(IRepositoryPtrnContext context)
        {
            _context = context;
        }

        public Repo2Item GetItem(int id)
        {
            return _context.Repo2Items.Where(a => a.Id == id).SingleOrDefault();
        }

        public IEnumerable<Repo2Item> GetAllItems()
        {
            return _context.Repo2Items.ToList();
        }


        public void Add(Repo2Item repo2Item)
        {
            _context.Repo2Items.Add(repo2Item);            
        }

    }
}
