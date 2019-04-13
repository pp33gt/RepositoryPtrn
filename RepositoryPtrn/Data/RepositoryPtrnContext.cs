using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPtrn.Models;

namespace RepositoryPtrn.Models
{
    public class RepositoryPtrnContext : DbContext, IRepositoryPtrnContext
    {
        public RepositoryPtrnContext (DbContextOptions<RepositoryPtrnContext> options)
            : base(options)
        {
        }

        public DbSet<RepositoryPtrn.Models.Repo1Item> Repo1Items { get; set; }
        public DbSet<RepositoryPtrn.Models.Repo2Item> Repo2Items { get; set; }
    }
}
