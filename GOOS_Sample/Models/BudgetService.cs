﻿using System;
using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRespository<Budget> _budgetRespository;

        public BudgetService(IRespository<Budget> budgetRespository)
        {
            _budgetRespository = budgetRespository;
        }

        public event EventHandler Created;

        public event EventHandler Updated;

        public void Create(BudgetAddViewModel model)
        {
            var budget = new Budget { Amount = model.Amount, YearMonth = model.Month };
            this._budgetRespository.Save(budget);
        }

        public void Read(Func<Budget, bool> any)
        {
            throw new NotImplementedException();
        }
    }
}