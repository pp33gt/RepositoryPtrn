using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryPtrn.Core;
using RepositoryPtrn.Core.ViewModels;
using RepositoryPtrn.Models;

namespace RepositoryPtrn.Controllers
{
    public class CompositeRepoController : Controller
    {
 
        private readonly IUnitOfWork _unitOfWork;

        public CompositeRepoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Repo1Item
        public IActionResult Create()
        {
            var model = new CompositRepoViewModel();
            model.Repo1Items = _unitOfWork.Repo1.GetAllItems();
            model.Repo2Items = _unitOfWork.Repo2.GetAllItems();

            return View(model);
        }


        // POST: Repo1Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SomeNumber, SomeName")] CompositRepoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SomeName == model.SomeNumber.ToString())
                {
                    if (int.TryParse(model.SomeNumber, out int someNumber))
                    {
                        _unitOfWork.Repo1.Add(new Repo1Item() { SomeNumber = someNumber });
                        _unitOfWork.Repo2.Add(new Repo2Item() { SomeName = model.SomeName });
                        await _unitOfWork.CompleteAsync();
                        return RedirectToAction(nameof(Create));
                    }
                    ModelState.AddModelError("number_not_an_int", "SomeNumber is not a number");                    
                }
                else
                {
                    ModelState.AddModelError("name_and_value_not_equal", "SomeName and SomeNumber are not equal");
                }
            }
            model.Repo1Items = _unitOfWork.Repo1.GetAllItems();
            model.Repo2Items = _unitOfWork.Repo2.GetAllItems();
            return View(model);
        }
        
    }
}
