using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingBackend.Controllers;

namespace TestingBackend.Models
{
    public class TestEdit
    {
        public string requestNo { get; set; }
        public string lastUpdate { get; set; }
        public string name { get; set; }
        public string header { get; set; }
        //public PicturePath leftLogo { get; set; }
        //public PicturePath rightLogo { get; set; }
        public string title { get; set; }
        public string registerCode { get; set; }
        public string resumeText { get; set; }
    }
}