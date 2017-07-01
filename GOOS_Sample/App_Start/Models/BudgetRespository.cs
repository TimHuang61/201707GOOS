using System;
using GOOS_Sample.Models;
using GOOS_Sample.Models.DataModels;

namespace GOOS_Sample.App_Start.Models
{
    public class BudgetRespository : IRespository<Budget>
    {
        public Budget Read(Func<Budget, bool> precidate)
        {
            throw new NotImplementedException();
        }

        public void Save(Budget entity)
        {
            using (var dbContext = new BudgetEntites())
            {
                dbContext.Budgets.Add(entity);
                dbContext.SaveChanges();
            }
        }
    }
}