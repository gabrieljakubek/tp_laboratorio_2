using Archivos;
using System;
using System.Collections.Generic;
using System.Text;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor profesor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de los alumnos de la jornada (Se le asigna la lista de alumnos siempre 
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
                    if (this == alumno)
                    {
                        this.alumnos.Add(alumno);
                    }

                    //this = this+alumno;
                }
            }
        }

        /// <summary>
        /// Propiedad de la clase de la jornada
        /// </summary>
        public EClases Clase
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
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna ture si se pudo realizar, caso contrario false</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto texto = new Texto();
            if (texto.Guardar(".//Jornada.txt", jornada.ToString()))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Retorna la informacion de la jornada guardada
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer(".//Jornada.txt", out string dato);
            return dato;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna toda la informacion de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR {1}",this.Clase, this.Instructor.ToString());
            
            sb.AppendLine("ALUMNOS:\r\n");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<-------------------------------->\r\n");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si un alumno tienen la misma clase que la jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            if (a == j.clase)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si un alumno no tienen la misma clase que la jornada
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jirnada si se encuentra cursando la misma clase
        /// </summary>
        /// <param name="j">Jornada a la que se le insertara el anumno</param>
        /// <param name="a">Alumno que se desea insertar</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
