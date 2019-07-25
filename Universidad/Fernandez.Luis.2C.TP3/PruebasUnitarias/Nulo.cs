using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace PruebasUnitarias
{
    [TestClass]
    public class Nulo
    {
        [TestMethod]
        public void VerNulo()
        {
            Persona A = new Profesor();

            Assert.IsNotNull(A);
        }
    }
}
