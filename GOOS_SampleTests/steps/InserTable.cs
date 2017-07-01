using GOOS_SampleTests.DataModels;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    public class InserTable
    {
        [Given(@"Budget table existed budgets")]
        public void GivenBudgetTableExistedBudgets(Table table)
        {
            //same with BudgetCreateSteps
            var budgets = table.CreateSet<Budget>();
            using (var dbcontext = new NorthwindEntities())
            {
                dbcontext.Budgets.AddRange(budgets);
                dbcontext.SaveChanges();
            }
        }
    }
}