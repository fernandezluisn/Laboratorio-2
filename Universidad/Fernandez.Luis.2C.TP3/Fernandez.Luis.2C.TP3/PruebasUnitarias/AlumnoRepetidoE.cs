using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace PruebasUnitarias
{
    [TestClass]
    public class AlumnoRepetidoE
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Alumno alumno1;
            Alumno alumno2;
            Universidad UTN=new Universidad();
            bool b = false;

            alumno1 = new Alumno(1, "juan", "Perez", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            alumno2 = new Alumno(1, "juan", "Perez", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
           
            try
            {
                UTN = UTN + alumno1;
                UTN = UTN + alumno2;
            }
            
            catch(Exception e)
            {
                b = true;
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
            
            if(b==false)
            {
                Assert.Fail();
            }
            
        }
    }
}
