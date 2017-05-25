using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NUnit.Framework;
using ZooWebApp.Controllers;

namespace ZooWebApp.Tests
{
    public class AnimalControllerTests
    {
        [Test]
        public void Animal_Controller_Index_Action_Should_Return_Index_View()
        {
            string expected = "Index";
            var controller= new AnimalController();

            var actionResult = controller.Index() as ViewResult;

            if (actionResult != null) Assert.AreEqual(expected, actionResult.ViewName);
        }

        [Test]
        public void Animal_Controller_List_Action_Should_Return_List_View()
        {
            string expected = "List";
            var controller = new AnimalController();

            var actionResult = controller.List() as ViewResult;

            if (actionResult != null) Assert.AreEqual(expected, actionResult.ViewName);
        }

        [Test]
        public void Animal_Controller_Animal_Action_Should_Return__Animal()
        {
            string expected = "_Animal";
            var controller = new AnimalController();

            var actionResult = controller._Animal() as ViewResult;

            if (actionResult != null) Assert.AreEqual(expected, actionResult.ViewName);
        }
    }
}