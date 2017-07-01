using System;
using GOOS_Sample;
using GOOS_Sample.Models;
using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests.Models
{
    [TestClass]
    public class BudgetServiceTest
    {
        private BudgetService _budgetService;
        private IRespository<Budget> _budgetRepositoryStub = Substitute.For<IRespository<Budget>>();

        [TestMethod]
        public void CreateTest_should_invoke_repository_one_time()
        {
            // test event 的結果
            _budgetService = new BudgetService(_budgetRepositoryStub);
            var wasCreated = false;
            _budgetService.Created += (sender, e) => wasCreated = true;
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            _budgetService.Create(model);
            _budgetRepositoryStub.Received().Save(Arg.Is<Budget>(x => x.Amount == 2000 && x.YearMonth == "2017-02"));

            Assert.IsTrue(wasCreated);
        }


        [TestMethod()]
        public void CreateTest_when_exist_record_should_update_budget()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);
            var budgetFromDb = new Budget { Amount = 999, YearMonth = "2017-02" };
            _budgetRepositoryStub.Read(Arg.Any<Func<Budget, bool>>()).ReturnsForAnyArgs(budgetFromDb);
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            var wasUpdated = false;
            this._budgetService.Updated += (sender, args) => wasUpdated = true;
            this._budgetService.Create(model);
            _budgetRepositoryStub.Received().Save(Arg.Is<Budget>(x => x == budgetFromDb && x.Amount == 2000));
            Assert.IsTrue(wasUpdated);
        }
    }
}
