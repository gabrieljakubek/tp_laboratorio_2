using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
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
                this.alumnos = value;
            }
        }

        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                this.jornadas.Add(value);
            }
        }
        #endregion

        #region Constructores
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo de clase privado que retorna toda la informacion de la universidad que se le pasa
        /// </summary>
        /// <param name="uni">universidad de la qué se desa obtener los datos</param>
        /// <returns></returns>
        private static string MostraDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in uni.jornadas)
            {
                sb.Append(jornada.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Guarda en un XML todos los datos de la universidad que se le pasa
        /// </summary>
        /// <param name="uni">Universidad que se desea guardar</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            XML<Universidad> xml = new XML<Universidad>();
            if (xml.Guardar(".//Universidad", uni))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Obtiene los datos de un XML que contienen una Universidad
        /// </summary>
        /// <returns>Universidad que se obtiene del archivo guardado</returns>
        public static Universidad Leer()
        {
            XML<Universidad> xml = new XML<Universidad>();
            xml.Leer(".//Universidad", out Universidad universidad);
            return universidad;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna toda la informacion de la Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostraDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara si una universidad ya cuenta con el alumno que se le pasa
        /// </summary>
        /// <param name="g">Universidad a la cual se le desea consultar</param>
        /// <param name="a">Alumno que se desea saber si ya está inscripto</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            if (g.alumnos.Count != 0)
            {
                foreach (Alumno alumno in g.alumnos)
                {
                    if (alumno == a)
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara si una universidad mo cuenta con el alumno que se le pasa
        /// </summary>
        /// <param name="g">Universidad a la cual se le desea consultar</param>
        /// <param name="a">Alumno que se desea saber si no está inscripto</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Comprueba si una universidad ya tiene inscripto al profesor
        /// </summary>
        /// <param name="g">Universidad a al cual se le desea consultar</param>
        /// <param name="i">Profesor el cual se desea saber si ya se encuentra inscripto</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si una universidad no tiene inscripto al profesor
        /// </summary>
        /// <param name="g">Universidad a al cual se le desea consultar</param>
        /// <param name="i">Profesor el cual se desea saber si no se encuentra inscripto</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Comprueba si la universidad cuenta con algun profesor que imparta la clase con la que se le esta comparando
        /// </summary>
        /// <param name="u">Universidad a al aque sele desea consultar</param>
        /// <param name="clase">Clase por la que se está buscando profesor</param>
        /// <returns>Primer profesor que imparta la misma clas, caso contrario generará SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Comprueba si la universidad cuenta con algun profesor que no imparta la clase con la que se le esta comparando
        /// </summary>
        /// <param name="u">Universidad a al aque sele desea consultar</param>
        /// <param name="clase">Clase por la que se está buscando un profesor que no la imparta</param>
        /// <returns>Primer profesor que no imparta la misma clas, caso contrario generará SinProfesorException</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega un alumno si no se encuentra ya inscripto en la universidad
        /// </summary>
        /// <param name="u">Universidad que se desea consultar</param>
        /// /// <param name="a">Alumno que se desea agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor si no se encuentra inscripto en la universidad
        /// </summary>
        /// <param name="u">Universidad que se desea consultar</param>
        /// <param name="i">Profesor que se desea agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Agrega una clase del tipo que se especifica
        /// </summary>
        /// <param name="g">Uaniversidad a al que se le desea agregar una clase</param>
        /// <param name="clase">Tipo de clase que se desea agregar</param>
        /// <returns>Uiversidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            jornada.Alumnos = g.alumnos;
            g.jornadas.Add(jornada);
            return g;
        }
        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
