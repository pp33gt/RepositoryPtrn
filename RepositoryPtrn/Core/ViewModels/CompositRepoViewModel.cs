using RepositoryPtrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPtrn.Core.ViewModels
{
    public class CompositRepoViewModel
    {
        public IEnumerable<Repo1Item> Repo1Items { get; set; }

        public IEnumerable<Repo2Item> Repo2Items { get; set; }

        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string SomeNumber { get; set; }


        //[DataType(DataType.Text)]
        //[Required, MaxLength(3), MinLength(1)]
        public string SomeName { get; set; }

    }
}
