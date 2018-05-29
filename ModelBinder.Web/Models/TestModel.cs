using System.Collections.Generic;

namespace ModelBinder.Web.Models
{
    public class TestModel
    {
        public int a { get; set; }

        public string b { get; set; }

        public List<int> c { get; set; }

        public List<string> d { get; set; }
    }
}