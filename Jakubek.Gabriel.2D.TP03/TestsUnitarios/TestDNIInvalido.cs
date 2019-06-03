using System;
using EntidadesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestDniInvalido
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestAlumnoDniInvalido()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "a12234458",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
        }
    }
}
