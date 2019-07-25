using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class ValorNumerico
    {
        [TestMethod]
        public void TestMethod1()
        {
            int dni1=3000333;
            int dni2 = 4444222;



            
                Assert.AreNotEqual(dni1, dni2);
            
            
            
        }
    }
}
