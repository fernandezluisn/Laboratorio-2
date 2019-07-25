using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class NacionalidadInvalidaE
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool b = false;
            try
            {
                Alumno alumno = new Alumno(1, "juan", "Perez", "33333333", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                b = true;
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            if (b==false)
            {
                Assert.Fail();
            }
        }
    }
}
