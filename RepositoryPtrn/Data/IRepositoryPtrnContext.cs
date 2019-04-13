using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPtrn.Models
{
    public interface IRepositoryPtrnContext
    {
        DbSet<Repo1Item> Repo1Items { get; set; }
        DbSet<Repo2Item> Repo2Items { get; set; }

    }
}
