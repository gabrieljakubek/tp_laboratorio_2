using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> claseDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// inicializa el Random
        /// </summary>
        static Profesor()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Constructor que asigna los datos al objeto Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<EClases>();
            this.RandomClases();
            this.RandomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta una clase aleatoriamente
        /// </summary>
        private void RandomClases()
        {
            this.claseDelDia.Enqueue((EClases)random.Next(0,3));
        }

        /// <summary>
        /// Metodo encargado de mostrar los datos del objeto
        /// </summary>
        /// <returns>Retorna todos los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo encargado de mostrar cual es la clase del día
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("CLASE DEL DIA " + this.claseDelDia.Dequeue().ToString());
            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si un profesor dicta una clase en especifico 
        /// </summary>
        /// <param name="i">Profesor delque se desea comprobar</param>
        /// <param name="clase">Ckase que se desea comprobar</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            if (i.claseDelDia.Peek() == clase)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si un profesor no dicta una clase en especifico 
        /// </summary>
        /// <param name="i">Profesor delque se desea comprobar</param>
        /// <param name="clase">Ckase que se desea comprobar</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
