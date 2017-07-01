﻿using System;
using System.Text;
using System.Collections.Generic;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests.Controllers
{
    /// <summary>
    /// Summary description for BudgetControllerTest
    /// </summary>
    [TestClass]
    public class BudgetControllerTest
    {
        private BudgetController _budgetController;
        private IBudgetService budgetServiceStub = Substitute.For<IBudgetService>();

        public BudgetControllerTest()
        {
            _budgetController = new BudgetController(budgetServiceStub);
        }

        public void AddTest_add_budget_successfully_should_invoke_budgetService_Create_one_time()
        {
            _budgetController = new BudgetController(budgetServiceStub);
            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };
            var result = _budgetController.Add(model);
            budgetServiceStub.Received().Create(Arg.Is<BudgetAddViewModel>(x => x.Amount == 2000 && x.Month == "2017-02"));
        }
    }
}
