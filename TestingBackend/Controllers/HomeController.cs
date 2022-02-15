using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TestingBackend.Models.JsonSchema;
using TestingBackend.Models.MyDataClasses;
using TestingBackend.Models;

namespace TestingBackend.Controllers
{
	public class HomeController : Controller
	{
		List<Form> Forms = new List<Form>();

		public ActionResult Index()
        {
			Form form1 = new Form()
			{
				id = "1",
				code = "Codigo F1",
				name = "Formulario 1",
				address = "Dirección de Sanidad Animal",
				json = "",
				data = ""
			};
			Form form2 = new Form()
			{
				id = "2",
				code = "Codigo F2",
				name = "Formulario 2",
				address = "Dirección de Sanidad Vegetal",
				json = "",
				data = ""
			};
			Forms.Add(form1);
			Forms.Add(form2);
			ViewBag.List = Forms;
			ViewData["Form"] = Forms;
            return View(Forms);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(string JsonData)
        {
            MyData myData = JsonConvert.DeserializeObject<MyData>(JsonData);
            string OldJson = LoadForm(myData);
            string NewJson = OldJson.Replace(@"""%""", "");
            NewJson = NewJson.Replace(@"""%\""", "");
			NewJson = NewJson.Replace(@"\", "");
			Form form = new Form()
			{
				id =  "3",
				code = myData.registerCode,
				name = myData.name,
				address = myData.direction,
				json = NewJson,
				data = JsonConvert.SerializeObject(myData)
			};
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

        public string LoadForm(MyData data)
        {
            List<SchemaSaver> FDRList = new List<SchemaSaver>();
			List<FormSchema> formList = new List<FormSchema>();
			FormSchema header = new FormSchema { key="",type = "htmlsnippet", value= "<h4>"+data.header+"</h4>" };
			formList.Add(header);
			FormSchema address = new FormSchema { key = "" ,type = "htmlsnippet", value = "<h4>" + data.direction + "</h4>" };
			formList.Add(address);
			FormSchema title = new FormSchema { key = "",type = "htmlsnippet", value = "<h2>" + data.title + "</h2>" };
			formList.Add(title);
			FormSchema code = new FormSchema { key = "", type = "htmlsnippet", value = "<h2>" + data.registerCode + "</h2>" };
			formList.Add(code);
			FormSchema resumeText = new FormSchema { key = "",type = "htmlsnippet", value = "<h4>" + data.resumeText + "</h4>" };
			formList.Add(resumeText);
			int fields = 1;
			foreach (var item in data.fields)
			{
				FormSchema formField = new FormSchema { key = "campo"+fields, type = "text", value="" };
				formList.Add(formField);
                SchemaSaver SaverAux = new SchemaSaver();
                SaverAux.name = item;
                SaverAux.title = "campo" + fields;
                FDRList.Add(SaverAux);
				fields++;
			}
			int disclaimers = 1;
			foreach (var item in data.disclaimers)
			{
				FormSchema formDisclaimer = new FormSchema { key = "", type = "htmlsnippet" ,value = "<h4>" + item + "</h4>" };
				formList.Add(formDisclaimer);
                disclaimers++;
			}
			int requirement = 1;
			foreach (var item in data.requirements)
			{
				FormSchema formRequirements = new FormSchema { key = "requirement"+requirement, type = "file" , value=""};
				formList.Add(formRequirements);
                SchemaSaver SaverAux = new SchemaSaver();
                SaverAux.name = item;
                SaverAux.title = "requirement" + requirement;
                FDRList.Add(SaverAux);
                requirement++;
			}
            string SchemaString = Convert.ToString('%') + Convert.ToString('"') + Convert.ToString('{');
            foreach (var item in FDRList)
            {
                SchemaString += '"' + item.title + '"' + @":{""type"":""string""," + @"""title"":" + '"' + item.name + '"' + "},";
            }
            SchemaString = SchemaString.Remove(SchemaString.Length - 1, 1);
            SchemaString += Convert.ToString('}') + Convert.ToString('"')+ Convert.ToString('%');
			
            SchemaJson schemaJson = new SchemaJson
            {
                schema = SchemaString,
                form = formList
            };
			return JsonConvert.SerializeObject(schemaJson);

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