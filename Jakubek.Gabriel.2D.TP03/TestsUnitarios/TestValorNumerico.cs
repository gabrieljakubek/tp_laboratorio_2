using System;
using EntidadesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestValorNumerico
    {
        [TestMethod]
        public void TestTipoNumero()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Assert.IsInstanceOfType(a1.DNI, typeof(int));
        }

        [TestMethod]
        public void TestIgualValor()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "1",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Assert.AreEqual(1, a1.DNI);
        }
    }
}
