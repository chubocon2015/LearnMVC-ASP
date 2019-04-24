using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;



namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new HoangEntities();
            var controller = new ProductControllerTest();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model,
                typeof(List<Product>));
            Assert.AreEqual(db.Products.Count(),
                (result.Model as List<Product>).Count);
        }
        [TestMethod]
        public void TestEdit()
        {
            var controller = new ProductControllerTest();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new HoangEntities();
            var item = db.Products.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Product;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
        }
    }
}
