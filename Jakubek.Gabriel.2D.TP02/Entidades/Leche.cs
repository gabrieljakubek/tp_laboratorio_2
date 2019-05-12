using System;
using System.Text;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Enumerador
        public enum ETipo
        {
            Entera,
            Descremada
        }
        #endregion

        #region Atributos
        private ETipo tipo;
        #endregion

        #region Cosntructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color) : this(marca, codigoDeBarras, color, ETipo.Entera)
        {
        }

        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color, ETipo tipo) : base(codigoDeBarras, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna la informacion de la leche
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\r\n", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
