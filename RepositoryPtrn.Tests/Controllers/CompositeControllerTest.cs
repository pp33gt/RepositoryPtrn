using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryPtrn.Controllers;
using RepositoryPtrn.Core;
using RepositoryPtrn.Core.Repositories;
using RepositoryPtrn.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace RepositoryPtrn.Tests.Controllers
{
    [TestClass]
    public class CompositeControllerTest
    {
        private CompositeRepoController _compositeRepoController;

        private Mock<IRepository1> _mockRepository1;

        private Mock<IRepository2> _mockRepository2;

        [TestInitialize]
        public void Initialize()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockRepository1 = new Mock<IRepository1>();
            _mockRepository2 = new Mock<IRepository2>();
            _compositeRepoController = new CompositeRepoController(mockUnitOfWork.Object);
            mockUnitOfWork.SetupGet(u => u.Repo1).Returns(_mockRepository1.Object);
            mockUnitOfWork.SetupGet(u => u.Repo2).Returns(_mockRepository2.Object);

            _compositeRepoController = new CompositeRepoController(mockUnitOfWork.Object);
        }

        [TestMethod]
        public void Create_ValuesAreNotEqual_ShouldReturnModelStateInvalid()
        {
            // Arrange
            var model = new CompositRepoViewModel();
            model.SomeName = "foo";
            model.SomeNumber = "123";

            // Act
            var task = _compositeRepoController.Create(model);
            if(task.Result is ViewResult viewResult)
            {
                var modelState = viewResult.ViewData.ModelState;

                // Assert
                Assert.IsFalse(modelState.IsValid, "Submit someName foo and SomeNumber 123 Should give ModelState Invalid");
                return;
            }

            Assert.Fail("Unexpected return type");
        }


        [TestMethod]
        public void Create_ValuesAreNumeric_ShouldReturnRedirectActionNameCreate()
        {
            // Arrange
            var model = new CompositRepoViewModel();
            model.SomeName = "123";
            model.SomeNumber = "123";

            // Act
            var task = _compositeRepoController.Create(model);
            if (task.Result is RedirectToActionResult redirect)
            {
                var actualActionName = redirect.ActionName;
                var expectedActionName = "Create";

                // Assert
                Assert.AreSame(expectedActionName, actualActionName, "Create with equal numbers Should return RedirectToActionResult and ActionName Create");
                return;
            }

            Assert.Fail("Unexpected return type");
        }


        [TestMethod]
        public void Create_ValuesAreNonNumeric_ShouldReturnModelStateInvalid()
        {            
            // Arrange
            var model = new CompositRepoViewModel();
            model.SomeName = "foo";
            model.SomeNumber = "foo";

            // Act
            var task = _compositeRepoController.Create(model);
            if (task.Result is ViewResult viewResult)
            {
                // Assert
                var modelState = viewResult.ViewData.ModelState;
                modelState.IsValid.Should().BeFalse();
                //Assert.IsFalse(modelState.IsValid, "Create with values foo Should give ModelState Invalid");
                return;
            }

            Assert.Fail("Unexpected return type");
        }
    }
}
