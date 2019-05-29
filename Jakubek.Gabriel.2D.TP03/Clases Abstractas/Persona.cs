using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
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

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
            : this(nombre, apellido, 0, nacionalidad)
        { }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        { }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            string mensaje = "DNI invalido";
            if (dato >= 1 && dato <= 99999999)
            {
                    if ((nacionalidad != ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) ||
                        (nacionalidad != ENacionalidad.Extrangero && dato >= 90000000 && dato <= 99999999))
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
            Extrangero
        }
    }
}
