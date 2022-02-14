using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TestingBackend.Models;

namespace TestingBackend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(string JsonData)
        {
			
            
            var serializer = new JavaScriptSerializer();
            //dynamic obj = serializer.Deserialize(JsonData, typeof(object));
            TestEdit testEdit = JsonConvert.DeserializeObject<TestEdit>(JsonData);
            
            //dynamic id = myFormDetail.myFormDetail;
            //Dictionary<System.String, System.Object> diccionario1 = new Dictionary<System.String, System.Object>();

            //diccionario1 = obj[10];
            
            //List<string> DisclaimersList = new List<string>();
            //List<string> RequirementsList = new List<string>();
            //dynamic data = JsonConvert.DeserializeObject(JsonData, typeof(object));
            //var list = data.disclaimers as IEnumerable<dynamic>;
            //string datos = list.ToString();
            //DisclaimersList = EliminacionLetras(datos);
            //list = data.requirements as IEnumerable<dynamic>;
            //datos = list.ToString();
            //RequirementsList = EliminacionLetras(datos);
            /*
            dynamic data = JsonConvert.DeserializeObject(JsonData, typeof(object));
            var list = data.Response.Outcome.KeyValueOfstringOutcomepQnxSKQu as IEnumerable<dynamic>;
            var iconNode = list.FirstOrDefault(r => r.Key == "Icon");
            var valueOfO = iconNode.Value.Value.Value;*/

            return Json(testEdit);
        }

        public JsonResult Edit(string ID)
        {
            List<string> Fields = new List<string>
            {
                "Campo 1",
                "Campo 2",
                "Campo 3"
            };

            List<string> Disclaimers = new List<string>
            {
                "Disclaimer 1",
                "Disclaimer 2",
                "Disclaimer 3"
            };

            List<string> Requeriments = new List<string>
            {
                "Requeriment 1",
                "Requeriment 2",
                "Requeriment 3"
            };

            TestEdit obj = new TestEdit
            {
                requestNo = "XLMAA0",
                lastUpdate = "12/12/12",
                name = "JOSE GIRON",
                //direction = "direccion nueva",
                header = "SOY UN ENCABEZADO",
                title = "SOY UN TITULO",
                registerCode = "CODIGO DE REGISTRO",
                resumeText = "SOY UN RESUMEN",
                //fields = Fields,
                //disclaimers = Disclaimers,
                //requirements = Requeriments
            };

            return Json(obj);
        }

        public List<string> EliminacionLetras(string datos)
        {
            List<string> listapalabras = new List<string>();
            if (datos != "{}")
            {
                datos = datos.Remove(0, 1);
                datos = datos.Remove(datos.Length - 1, 1);
                char[] charsToTrim = { '{', '}', ' ', '"' };
                string result = datos.Trim(charsToTrim);
                datos = datos.Replace("\r\n", string.Empty);
                datos = datos.Remove(0, 7);
                datos = datos.Trim('{', '}', ' ');
                string[] Separacion1 = datos.Split(',');
                foreach (var item in Separacion1)
                {
                    string[] separacion2 = item.Split(':');
                    separacion2[1] = separacion2[1].Remove(0, 2);
                    separacion2[1] = separacion2[1].Remove(separacion2[1].Length - 1, 1);
                    listapalabras.Add(separacion2[1]);
                }
            }
            
            return listapalabras;
        }
    }
}