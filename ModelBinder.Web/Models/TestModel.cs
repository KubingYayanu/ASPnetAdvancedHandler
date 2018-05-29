using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBinder.Web.Models
{
    public class TestModel
    {
        public int a { get; set; }

        public string b { get; set; }

        public IList<int> c { get; set; }

        public IList<string> d { get; set; }
    }
}