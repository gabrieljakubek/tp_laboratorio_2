using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> claseDelDia;
        private static Random random;
        #endregion

        #region Constructores
        static Profesor()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public Profesor()
        {
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<EClases>();
            this.RandomClases();
            this.RandomClases();
        }
        #endregion

        #region Metodos
        private void RandomClases()
        {
            this.claseDelDia.Enqueue((EClases)random.Next(0,3));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("CLASE DEL DIA " + this.claseDelDia.Peek().ToString());
            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion


    }
}
