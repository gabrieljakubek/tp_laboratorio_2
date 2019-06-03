using System;
using EntidadesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestNulos
    {
        [TestMethod]
        public void TestAlumnoNoNulo()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(a1);
        }

        [TestMethod]
        public void TestNombreNoNulo()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(a1.Nombre);
        }

        [TestMethod]
        public void TestProfesorNoNulo()
        {
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(i1);
        }
    }
}
