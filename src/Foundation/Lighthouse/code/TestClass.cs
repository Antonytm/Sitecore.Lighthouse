using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Lighthouse
{
    public class TestClass
    {
        public bool SonarTest { get; set; }
        public void Test()
        {
            if (SonarTest)
            {
                Console.Write("Success");
            }
        }
    }
}