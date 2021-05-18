using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using WebApplication5.Controllers;
using WebApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Linq;


using System.Web.Mvc;


namespace WebApplication5.Controllers.Tests
{
    

    [TestClass()]
    public class HomeControllerTests
    {
        // HOME CONTROLLER

        [TestMethod()]
        public void IndexTest()
        {
            var hc = new HomeController();
            var r = hc.Index() as ViewResult;
            Assert.IsInstanceOfType(r, typeof(ViewResult));
        }

        [TestMethod()]
        public void AboutTest()
        {
            var hc = new HomeController();
            var r = hc.About() as ViewResult;
            Assert.IsInstanceOfType(r, typeof(ViewResult));
        }

        // DEPARTMENT CONTROLLER

        [TestMethod()]
        public void DepartmentIndexTest()
        {
            var dc = new DepartmentController();
            var r = dc.Index() as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void DepartmentDetailsTest()
        {
            var dc = new DepartmentController();
            var r = dc.Details(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void DepartmentCreateTest()
        {
            var dc = new DepartmentController();
            var r = dc.Create() as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void DepartmentEditTest()
        {
            var dc = new DepartmentController();
            var r = dc.Edit(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void DepartmentDeleteTest()
        {
            var dc = new DepartmentController();
            var r = dc.Delete(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        // TICKET CONTROLLER

        [TestMethod()]
        public void TicketTest()
        {
            var tc = new TicketController();
            var r = tc.Index("","","",1) as ViewResult;
            Assert.IsInstanceOfType(r, typeof(ViewResult));
        }

        [TestMethod()]
        public void TicketCreateTest()
        {
            var tc = new TicketController();
            var r = tc.Create() as ViewResult;
            Assert.IsInstanceOfType(r, typeof(ViewResult));
        }

        [TestMethod()]
        public void TicketEditTest()
        {
            var ac = new TicketController();
            var r = ac.Edit(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void TicketDeleteTest()
        {
            var ac = new TicketController();
            var r = ac.Delete(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        // AGENT CONTROLLER

        [TestMethod()]
        public void AgentIndexTest()
        {
            var ac = new AgentController();
            var r = ac.Index("","","",1) as ViewResult;
            Assert.IsInstanceOfType(r, typeof(ViewResult));
        }

        [TestMethod()]
        public void AgentCreateTest()
        {
            var ac = new AgentController();
            var r = ac.Create() as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void AgentEditTest()
        {
            var ac = new AgentController();
            var r = ac.Edit(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void AgentDetailsTest()
        {
            var ac = new AgentController();
            var r = ac.Details(1) as ViewResult;
            Assert.IsNotNull(r);
        }

        // KEYWORDS CONTROLLER

        [TestMethod()]
        public void KeywordsIndexTest()
        {
            var cc = new KeywordsDepartmentsController();
            var r = cc.Index() as ViewResult;
            Assert.IsInstanceOfType(r, typeof(ViewResult));
        }

        [TestMethod()]
        public void KeywordsCreateTest()
        {
            var cc = new KeywordsDepartmentsController();
            var r = cc.Create() as ViewResult;
            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void KeywordsEditTest()
        {
            var cc = new KeywordsDepartmentsController();
            var r = cc.Edit(1) as ViewResult;
            Assert.IsNull(r);
        }

        [TestMethod()]
        public void KeywordsDetailsTest()
        {
            var cc = new KeywordsDepartmentsController();
            var r = cc.Details(1) as ViewResult;
            Assert.IsNull(r);
        }

        [TestMethod()]
        public void KeywordsDeleteTest()
        {
            var cc = new KeywordsDepartmentsController();
            var r = cc.Delete(1) as ViewResult;
            Assert.IsNull(r);
        }


    }
}