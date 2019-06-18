using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TackingIDReperido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]¡
        public void TestMethod1()
        {
            Paquete paquete = new Paquete("Mitre 359", "12356215");
            Paquete paquete2 = new Paquete("VEracruz 120", "12356215");
            Correo correo = new Correo();
            correo += paquete;
            correo += paquete2;
        }
    }
}
