using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingBackend.Models
{
    public class Storage
    {
        //instance element
        private static Storage _instance = null;

        //method for instance
        public static Storage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Storage();
                return _instance;
            }
        }
        public List<Form> Forms = new List<Form>();
    }
}