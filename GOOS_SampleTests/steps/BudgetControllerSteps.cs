using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_SampleTests.Commons;
using GOOS_SampleTests.DataModels;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    // 整合測試
    [Binding]
    [Scope(Feature = "BudgetController")]
    public class BudgetControllerSteps
    {
        private BudgetController _budgetController = Hooks.UnityContainer.Resolve<BudgetController>();

        private readonly InserTable _inserTable = new InserTable();
        // private BudgetController _budgetController = new BudgetController(new BudgetService());

        [When(@"add a budget")]
        public void WhenAddABudget(Table table)
        {
            var model = table.CreateInstance<BudgetAddViewModel>();
            var result = this._budgetController.Add(model);
            ScenarioContext.Current.Set(result);
        }
        
        [Then(@"ViewBag should have a message for adding successfully")]
        public void ThenViewBagShouldHaveAMessageForAddingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetAddingSuccessfullyMessage());
        }
        
        [Then(@"it should exist a budget record in budget table")]
        public void ThenItShouldExistABudgetRecordInBudgetTable(Table table)
        {
            // 連測試DB.
            using (var dbcontext = new NorthwindEntities())
            {
                var budget = dbcontext.Budgets.FirstOrDefault();
                budget.Should().NotBeNull();
                table.CompareToInstance(budget);
            }
        }

        private static string GetAddingSuccessfullyMessage()
        {
            return "added successfully";
        }

        [Then(@"ViewBag should have a message for updating successfully")]

        public void ThenViewBagShouldHaveAMessageForUpdatingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetUpdatingSuccessfullyMessage());
        }

        private string GetUpdatingSuccessfullyMessage()
        {
            return "updated successfully";
        }
    }
}
