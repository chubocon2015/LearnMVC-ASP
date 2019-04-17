using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Tests.Controllers
{
    [TestClass]
    public class ExpenditureControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new HoangEntities();
            var controller = new Default1Controller();

            var result = controller.Index() as ViewResult;          
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model,
                typeof(List<Expenditure>));
            Assert.AreEqual(db.Expenditures.Count(),
                (result.Model as List<Expenditure>).Count);
        }
    }
}
