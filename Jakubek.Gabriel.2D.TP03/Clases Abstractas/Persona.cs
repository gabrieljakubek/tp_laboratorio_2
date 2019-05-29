using Excepciones;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad del atributo DNI (se le asignara el dni siempre y cuando sea valido)
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad el Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad que asigna un DNI en formato string siempre y cuando cumpla con los requisitos
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Constructor que recibe los datos de una persona a excepcion del dni
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
            : this(nombre, apellido, 0, nacionalidad)
        { }

        /// <summary>
        /// Cosntructor que recibe todos los ddatos de la persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        { }

        /// <summary>
        /// Cosntructor que recibe todos los ddatos de la persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que comprueba si un DNI es apto o no
        /// </summary>
        /// <param name="nacionalidad">NAcionalidad de la persona</param>
        /// <param name="dato">DNi que se desea saber si es apto o no</param>
        /// <returns>Si cumple con los requisitos retorna el DNI, caso contrario se genera un DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            string mensaje = "DNI invalido";
            if (dato >= 1 && dato <= 99999999)
            {
                    if ((nacionalidad != ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) ||
                        (nacionalidad != ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
                    {
                        throw new NacionalidadInvalidaException("Nacionalidad invalida");
                    }
                    else
                    {
                        retorno = dato;
                    }
            }
            else
            {
                throw new DniInvalidoException(mensaje);
            }

            return retorno;
        }

        /// <summary>
        /// Valida si la cadena es un numero y combreba que cumpla con los requisitos
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Cadena de caracteres que se desea comprobar si es un dni apto</param>
        /// <returns>Si cumple con los requisitos retorna el DNI, caso contrario se genera un DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            string mensaje = "DNI invalido";
            if (!int.TryParse(dato, out int resultado) && dato.Count() < 9)
            {

                retorno = ValidarDni(nacionalidad, resultado);
            }
            else
            {
                throw new DniInvalidoException(mensaje);
            }

            return retorno;
        }

        /// <summary>
        /// Valida que un nombre o apellido sean correctos
        /// </summary>
        /// <param name="dato">Nombre/Apellido que se desea saber si es correcto</param>
        /// <returns>Si se cumple con los rquisitos retorna el Nombre/Apellido, caso contrario retorna "" </returns>
        private string ValidarNombreApellido(string dato)
        {
            bool chequeo = false;
            string retorno = "";
            foreach (char caracter in dato)
            {
                if (!char.IsLetter(caracter))
                {
                    chequeo = true;
                    break;
                }
            }
            if (chequeo)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Retorna toda la informacion de la PErsona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DNI: " + this.dni);
            sb.AppendLine("Nombre: " + this.nombre);
            sb.AppendLine("Apellido: " + this.apellido);
            sb.AppendLine("Nacionalidad: " + this.nacionalidad);
            return sb.ToString();
        }
        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
