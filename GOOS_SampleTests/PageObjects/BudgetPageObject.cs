using System;
using FluentAutomation;
using GOOS_SampleTests.steps;

namespace GOOS_SampleTests.PageObjects
{
    internal class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest test) : base(test)
        {
        }

        public BudgetCreatePage Amount(object amount)
        {
            throw new System.NotImplementedException();
        }

        public BudgetCreatePage Month(object yearMonth)
        {
            throw new System.NotImplementedException();
        }

        internal BudgetCreatePage AddBudget()
        {
            throw new NotImplementedException();
        }

        public BudgetCreatePage ShouldDisplay(string message)
        {
            throw new NotImplementedException();
        }
    }
}