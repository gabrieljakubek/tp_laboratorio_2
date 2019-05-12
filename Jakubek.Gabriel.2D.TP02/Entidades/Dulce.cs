using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor de dulce
        /// </summary>
        /// <param name="marca">Marca del dulce</param>
        /// <param name="codigoDeBarras">El codigo de barras del dulce</param>
        /// <param name="color">Color primario del empaque</param>
        public Dulce(EMarca marca, string codigoDeBarras, ConsoleColor color) : base(codigoDeBarras, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna toda la informacion del dulce
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion

    }
}
