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
        /// <summary>
        /// Propiedad de los alumnos de la jornada (Se le asigna la listade alumnos siempre 
        /// y cueando todos los alumnos asistan a la misma clase)
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                foreach (Alumno alumno in value)
                {
                    if (alumno == this.clase)
                    {
                        this.alumnos.Add(alumno);
                    }
                }
            }
        }

        /// <summary>
        /// Propiedad de la clase de la jornada
        /// </summary>
        public EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad del profesor de la jornada ( se le asigna el profesor siempre y cuando imparta esa misma clase)
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.profesor;
            }
            set
            {
                if (value == this.clase)
                {
                    this.profesor = value;
                }

            }
        }
        #endregion

        #region Constructores
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
        {
            this.Clases = clase;
            this.Instructor = instructor;
        }
        #endregion


    }
}
