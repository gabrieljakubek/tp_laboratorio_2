using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructor
        /// <summary>
        /// Constructor del Snack
        /// </summary>
        /// <param name="marca">MArca del snack</param>
        /// <param name="codigoDeBarras">Codigo de barras del snack</param>
        /// <param name="color">Color primario del empaque del snack</param>
        public Snacks(EMarca marca, string codigoDeBarras, ConsoleColor color) : base(codigoDeBarras, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna toda la informacion del snack
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
