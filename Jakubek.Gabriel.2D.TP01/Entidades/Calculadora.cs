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

        public double Operar(Numero num1, Numero num2, string operador)
        {
            string auxString = ValidarOperador(operador);
            double retorno = 0;
            switch (operador)
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
