using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingBackend.Models.JsonSchema
{
    public class FormSchema
    {
        public string key { get; set; }
        public string type { get; set; }
		public string value { get; set; } //para texto plano
	}
}