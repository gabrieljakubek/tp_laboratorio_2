using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza la operacion a los dos valosres que se le pasan
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            string auxString = ValidarOperador(operador);
            double retorno = 0;
            switch (auxString)
            {
                case "+":
                    {
                        retorno = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        retorno = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        retorno = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        retorno = num1 / num2;
                        break;
                    }
                default:
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Valida que el valor sea uno de los operadores permitidos, caso contrario retorna "+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "";
            if (operador != "*" && operador != "/" && operador != "+" && operador != "-")
            {
                retorno = "+";
            }
            else
            {
                retorno = operador;
            }
            return retorno;
        }

        #endregion
    }
}
