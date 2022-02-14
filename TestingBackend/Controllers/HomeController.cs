using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TestingBackend.Models.JsonSchema;
using TestingBackend.Models.MyDataClasses;

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
			
            //dynamic obj = serializer.Deserialize(JsonData, typeof(object));
            
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

            MyData myData = JsonConvert.DeserializeObject<MyData>(JsonData);

            return Json(myData);
        }

        public JsonResult Edit(string ID)
        {
            List<string> Fields = new List<string>{"Campo 1","Campo 2","Campo 3"};

            List<string> Disclaimers = new List<string>{"Disclaimer 1","Disclaimer 2","Disclaimer 3"};

            List<string> Requeriments = new List<string>{"Requeriment 1","Requeriment 2","Requeriment 3"};

            MyData obj = new MyData
            {
                requestNo = "XLMAA0",
                lastUpdate = "12/12/12",
                name = "nombre",
                direction = "direccion nueva",
                header = "SOY UN ENCABEZADO",
                title = "SOY UN TITULO",
                registerCode = "CODIGO DE REGISTRO",
                resumeText = "SOY UN RESUMEN",
                fields = Fields,
                disclaimers = Disclaimers,
                requirements = Requeriments
            };
            
            return Json(obj);
        }

        public JsonResult LoadForm()
        {
            FormSchema form1 = new FormSchema { key = "requestNo", type = "text" };
            FormSchema form2 = new FormSchema { key = "lastUpdate", type = "text" };
            FormSchema form3 = new FormSchema { key = "name", type = "text" };
            FormSchema form4 = new FormSchema { key = "direction", type = "text" };
            FormSchema form5 = new FormSchema { key = "header", type = "textarea" };
            FormSchema form6 = new FormSchema { key = "leftLogo", type = "file" };
            FormSchema form7 = new FormSchema { key = "rightLogo", type = "file" };
            FormSchema form8 = new FormSchema { key = "title", type = "textarea" };
            FormSchema form9 = new FormSchema { key = "registerCode", type = "text" };
            FormSchema form10 = new FormSchema { key = "resumeText", type = "textarea" };
            

            SchemaJson schemaJson = new SchemaJson
            {
                schema = new SchemaSchema
                {
                    requestNo = new StringSchema { title = "No. de Solicitud" },
                    lastUpdate = new StringSchema { title = "Última modificación" },
                    name = new StringSchema { title = "Nombre" },
                    direction = new StringSchema { title = "Dirección" },
                    header = new StringSchema { title = "Encabezado" },
                    leftLogo = new StringSchema { title = "Logo izquierdo" },
                    rightLogo = new StringSchema { title = "logo derecho" },
                    title = new StringSchema { title = "titulo" },
                    registerCode = new StringSchema { title = "codigo de registro" },
                    resumeText = new StringSchema { title = "un resumen de todo" }
                },
                form = new List<FormSchema>
                {
                    form1, form2, form3, form4, form5, form6, form7, form8, form9, form10
                }
            };


            return Json(schemaJson);
        }

        //metodo basura
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