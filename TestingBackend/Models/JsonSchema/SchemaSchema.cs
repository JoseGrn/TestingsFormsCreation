using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingBackend.Models.JsonSchema
{
    public class SchemaSchema
    {
        public StringSchema requestNo { get; set; }
        public StringSchema lastUpdate { get; set; }
        public StringSchema name { get; set; }
        public StringSchema direction { get; set; }
        public StringSchema header { get; set; }
        public StringSchema leftLogo { get; set; }
        public StringSchema rightLogo { get; set; }
        public StringSchema title { get; set; }
        public StringSchema registerCode { get; set; }
        public StringSchema resumeText { get; set; }
    }
}