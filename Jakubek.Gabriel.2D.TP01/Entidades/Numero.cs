using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad que setea el valor del numero previamente validado
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero() : this(Convert.ToString(0))
        {
        }

        /// <summary>
        /// Constructor que recibe como parametro un double
        /// </summary>
        /// <param name="numero">Valor que se desea asignar al numero</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Constructor que recive por parametro un string
        /// </summary>
        /// <param name="strNumero">Valor que se desea asignar al numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida si el valor que se le pasa es un numero o no
        /// </summary>
        /// <param name="strNumero">string el cual se desea comprobar si es un numero</param>
        /// <returns>retorna el numero convertido en double, en caso contrario "0"</returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))
            {
                return retorno;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que convierte un binario en un número decimal
        /// </summary>
        /// <param name="binario">Binario a convertir.</param>
        /// <returns>Valor entero resultado de la conversiónm caso contrario retornara "Valor invalido".</returns>
        public string BinarioDecimal(string binario)
        {
            double retorno = 0;
            bool flag = false;
            for (int i = 1; i <=binario.Length; i++)
            {
                if (binario[i-1] == '0' || binario[i-1] == '1')
                {
                    retorno += int.Parse(binario[i - 1].ToString()) * (double)Math.Pow(2, binario.Length - i);
                }
                else
                {
                    flag = true;
                }

            }
            if (flag)
            {
                return "Valor invalido";
            }
            else
            {
                return retorno.ToString();
            }

        }

        /// <summary>
        /// Convierte de decimal a binario recibiendo un double
        /// </summary>
        /// <param name="numero">Numero a convertir en binario</param>
        /// <returns>Retorna el binario correspondiente, caso contrario "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            int entero;
            string retorno = "";
            entero = Math.Abs((int)numero);
            do
            {
                retorno = (entero % 2).ToString() + retorno;
                entero /= 2;
            } while (entero >0);
            return retorno; ;
        }

        /// <summary>
        /// Convierte de decimal a binario recibiendo un string
        /// </summary>
        /// <param name="numero">Numero a convertir en binario</param>
        /// <returns>Retorna el binario correspondiente, caso contrario "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "";
            if (double.TryParse(numero, out double valor))
            {
                retorno = DecimalBinario(valor);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Operador que realiza la suma entre dos obj Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Operador que realiza la resta entre dos obj Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Operador que realiza la multiplicacion entre dos obj Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Operador que realiza la division entre dos obj Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la division</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        #endregion
    }

}
