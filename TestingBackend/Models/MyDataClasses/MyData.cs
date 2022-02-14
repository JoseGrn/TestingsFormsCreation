using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingBackend.Models.MyDataClasses
{
    public class MyData
    {
        public string requestNo { get; set; }
        public string lastUpdate { get; set; }
        public string name { get; set; }
        public string direction { get; set; }
        public string header { get; set; }
        public string title { get; set; }
        public string registerCode { get; set; }
        public string resumeText { get; set; }
        public List<string> fields { get; set; }
        public List<string> disclaimers { get; set; }
        public List<string> requirements { get; set; }
    }
}