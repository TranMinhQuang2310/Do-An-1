using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ExpenditureControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new QuanLiChiTieuEntities1();
            var controller = new ExpenditureController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<QLCT>));
            Assert.AreEqual(db.QLCTs.Count(), (result.Model as List<QLCT>).Count);
        }
    }
}
