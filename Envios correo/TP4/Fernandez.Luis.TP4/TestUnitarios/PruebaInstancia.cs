using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class PruebaInstancia
    {
        [TestMethod]
        public void PruebaInstanciaTest()
        {
            //arrange
            Correo correo = new Correo();
            Paquete paquete = new Paquete("vieytes 1400", "1111-111-111");
            //act
            correo = correo + paquete;
            //assert
            Assert.IsNotNull(correo);

        }
    }
}
