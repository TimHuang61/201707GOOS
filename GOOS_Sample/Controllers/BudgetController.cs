using GOOS_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            using (var dbContext = new BudgetEntites())
            {
                var budget = new Budget
                {
                    Amount = model.Amount,
                    YearMonth = model.Month
                };
                dbContext.Budgets.Add(budget);
                dbContext.SaveChanges();
            }

            ViewBag.Message = "added successfully";

            return View(model);
        }
    }
}