using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingBackend.Models.JsonSchema
{
    public class SchemaJson
    {
        public string schema { get; set; }
        public List<FormSchema> form { get; set; }
    }
}