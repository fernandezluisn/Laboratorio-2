using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class PruebaTrackingID
    {
        [TestMethod]
        [ExpectedException(typeof (TrackingIDRepetidoException))]
        public void TrackingIDTest()
        {
            //arrange
            Correo correo = new Correo();
            Paquete p1 = new Paquete("las cañas 123", "111");
            Paquete p2 = new Paquete("la rioja 144", "111");
            
            //act

            try
            {
                correo = correo + p1;
                correo = correo + p2;
            }
            catch (TrackingIDRepetidoException t)
            {
                t = new TrackingIDRepetidoException("Ya existe ese TrackingID");
                throw t;                
            }
            //assert
            

        }
    }
}