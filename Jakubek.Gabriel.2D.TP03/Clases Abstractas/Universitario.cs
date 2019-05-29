using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Universitario()
        { }

        /// <summary>
        /// Constructor que asigna todos los datos del universitario
        /// </summary>
        /// <param name="legajo">Legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo qué retorna toda la informacion del universitario 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Legajo: " + this.legajo);
            return sb.ToString();
        }
        #endregion

        #region Abstractos
        protected abstract string ParticiparEnClase();
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Comprueba si dos universitarios son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si dos universitarios son iguales cuando coinciden ser del mismo tipo y tener el mismo DNI o Legajo
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si dos universitarios no son iguales cuando no coinciden ser del mismo tipo y no tienen el mismo DNI o Legajo
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
