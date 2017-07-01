using System;
using FluentAutomation;
using GOOS_SampleTests.steps;

namespace GOOS_SampleTests.PageObjects
{
    internal class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        // 在這邊已經開始制定頁面的雛型
        public BudgetCreatePage(FluentTest test) : base(test)
        {
            // page context 資訊另外抽出來
            this.Url = $"{PageContext.Domain}/budget/add";
        }

        public BudgetCreatePage Amount(object amount)
        {
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        public BudgetCreatePage Month(object yearMonth)
        {
            I.Enter(yearMonth).In("#month");
            return this;
        }

        public void AddBudget()
        {
            I.Click("input[type=\"submit\"]");
        }

        public void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }
}