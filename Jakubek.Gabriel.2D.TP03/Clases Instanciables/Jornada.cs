using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor profesor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                ;
            }
        }

        public EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                ;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.profesor;
            }
            set
            {
                ;
            }
        }
        #endregion
    }
}
