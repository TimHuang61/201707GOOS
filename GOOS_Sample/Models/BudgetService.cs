using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRespository<Budget> _budgetRespositoryStub;

        public BudgetService(IRespository<Budget> budgetRespositoryStub)
        {
            _budgetRespositoryStub = budgetRespositoryStub;
        }

        public void Create(BudgetAddViewModel model)
        {
            using (var dbContext = new BudgetEntites())
            {
                var budget = new Budget { Amount = model.Amount, YearMonth = model.Month };
                dbContext.Budgets.Add(budget);
                dbContext.SaveChanges();
            }
        }
    }
}