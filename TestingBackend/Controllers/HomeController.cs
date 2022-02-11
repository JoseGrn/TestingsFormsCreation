using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
			
            /*
            var serializer = new JavaScriptSerializer();
            //serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
            dynamic obj = serializer.Deserialize(JsonData, typeof(object));
            //dynamic myFormDetail = JsonConvert.DeserializeObject<dynamic>(JsonData);
            //dynamic id = myFormDetail.myFormDetail;
            Dictionary<System.String, System.Object> diccionario1 = new Dictionary<System.String, System.Object>();

            diccionario1 = obj[10];
            */
            List<string> DisclaimersList = new List<string>();
            List<string> RequirementsList = new List<string>();
            dynamic data = JsonConvert.DeserializeObject(JsonData, typeof(object));
            var list = data.disclaimers as IEnumerable<dynamic>;
            string datos = list.ToString();
            DisclaimersList = EliminacionLetras(datos);
            list = data.requirements as IEnumerable<dynamic>;
            datos = list.ToString();
            RequirementsList = EliminacionLetras(datos);
            /*
            dynamic data = JsonConvert.DeserializeObject(JsonData, typeof(object));
            var list = data.Response.Outcome.KeyValueOfstringOutcomepQnxSKQu as IEnumerable<dynamic>;
            var iconNode = list.FirstOrDefault(r => r.Key == "Icon");
            var valueOfO = iconNode.Value.Value.Value;*/

            return Json(new { data = JsonData});
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