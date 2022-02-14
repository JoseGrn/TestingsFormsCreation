using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingBackend.Models;

namespace TestingBackend.Controllers
{
    public class TestEditController : Controller
    {
        // GET: TestEdit
        public ActionResult Index()
        {
            TestEdit test = new TestEdit()
            {
                requestNo = "XLMAA0",
                lastUpdate = "12/12/12",
                name = "JOSE GIRON",
                header = "SOY UN ENCABEZADO",
                title = "SOY UN TITULO",
                registerCode = "CODIGO DE REGISTRO",
                resumeText = "SOY UN RESUMEN"
            };
            ViewBag.Message = test;
            return View();
        }
    }
}