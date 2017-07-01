using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models.ViewModels;
using GOOS_SampleTests.DataModels;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    [Scope(Feature = "BudgetController")]
    public class BudgetControllerSteps
    {
        private BudgetController _budgetController = new BudgetController();

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
    }
}
