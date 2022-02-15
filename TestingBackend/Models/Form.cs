using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingBackend.Models
{
	public class Form
	{
		public string id { get; set; }
		public string code { get; set; }
		public string name { get; set; }
		public string address { get; set; }
		public string json { get; set; } //maquetado del formulario (PARA VISUALIZAR)
		public string data { get; set; } //datos llenados como encabezado, titulo, campos (PARA EDIT)
	}
}