using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        #region Enumeradores
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #endregion

        #region Atributos
        List<Producto> productos;
        int espacioDisponible;
        #endregion


        #region "Constructores"
        /// <summary>
        /// Cosntructor por default que inicia la lista de productos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor que asigna la cantidad de espacios disponibles
        /// </summary>
        /// <param name="espacioDisponible">Cantidad de espacios disponibles para productos</param>
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (v is Snacks)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if (v is Dulce)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if (v is Leche)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            //if (c != p && c.productos.Count() < c.espacioDisponible)
            //{
            //    c.productos.Add(p);
            //}
            bool chequeo = false;
            if (c.productos.Count() == 0)
            {
                c.productos.Add(p);
            }
            else
            {
                foreach (Producto v in c.productos)
                {
                    if (c.productos.Count() < c.espacioDisponible && v != p)
                    {
                        chequeo = true;
                    }
                    else
                    {
                        chequeo = false;
                        break;
                    }
                }
            }
            if (chequeo)
            {
                c.productos.Add(p);
            }
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            //if (c == p)
            //{
            //    c.productos.Remove(p);
            //}
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(p);
                    break;
                }
            }
            return c;
        }

        ///// <summary>
        ///// Comprobara si un objeto está insertado en la lista
        ///// </summary>
        ///// <param name="c">Objeto donde se comprobara</param>
        ///// <param name="p">Objeto a comprobar</param>
        ///// <returns></returns>
        //public static bool operator ==(Changuito c, Producto p)
        //{
        //    bool retorno = false;
        //    foreach (Producto producto in c.productos)
        //    {
        //        if (producto == p)
        //        {
        //            retorno = true;
        //            break;
        //        }
        //    }
        //    return retorno;
        //}

        ///// <summary>
        ///// Comprobara si un objeto no está insertado en la lista
        ///// </summary>
        ///// <param name="c"></param>
        ///// <param name="p"></param>
        ///// <returns></returns>
        //public static bool operator !=(Changuito c, Producto p)
        //{
        //    return !(c == p);
        //}
        #endregion
    }
}
