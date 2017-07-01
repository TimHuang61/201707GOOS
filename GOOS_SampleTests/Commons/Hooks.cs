using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FluentAutomation;
using GOOS_Sample.Models;
using GOOS_SampleTests.DataModels;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Commons
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        [Scope(Tag = "web")]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }


        [BeforeScenario]
        public void BeforeScenarioCleanTable()
        {
            CleanTableByTags();
        }

        [AfterFeature]
        public static void AfterFeatureCleanTable()
        {
            CleanTableByTags();
        }


        [BeforeTestRun()]
        public static void RegisterDIContainer()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IBudgetService, BudgetService>();
        }

        public static IUnityContainer UnityContainer { get; set; }

        private static void CleanTableByTags()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags.Where(x => x.StartsWith("Clean")).Select(x => x.Replace("Clean", "")).ToList();
            if (!tags.Any())
            {
                return;
            }

            using (var dbcontext = new NorthwindEntities())
            {
                tags.ForEach(tag => dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE {tag}"));
                dbcontext.SaveChangesAsync();
            }
        }


        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    //TODO: implement logic that has to run after executing each scenario
        //}
    }
}
