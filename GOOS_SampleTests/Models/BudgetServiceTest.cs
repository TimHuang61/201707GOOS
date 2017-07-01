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
        private IRespository<Budget> _budgetRespositoryStub = Substitute.For<IRespository<Budget>>();

        [TestMethod]
        public void CreateTest_should_invoke_repository_one_time()
        {
            _budgetService = new BudgetService(_budgetRespositoryStub);
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            _budgetService.Create(model);
            _budgetRespositoryStub.Received().Save(Arg.Is<Budget>(x => x.Amount == 2000 && x.YearMonth == "2017-02"));
        }
    }
}
