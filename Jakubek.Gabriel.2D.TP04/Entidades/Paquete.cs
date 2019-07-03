using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoEstado(object sender, EventArgs e);
    public delegate void DelegadoError(string mensaje);
    public class Paquete : IMostrar<Paquete>
    {
        public event DelegadoEstado InformarEstado;
        public event DelegadoError ErrorConeccion;
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento">PAquete que se desea mostrar</param>
        /// <returns>Retorna el trackID seguido de la direccion de entrega</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Simula el siclo de vida del paquete, guarda en la base de datos cada uno de los estados
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformarEstado.Invoke(this, new EventArgs());
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                this.ErrorConeccion("Error de conección a la base de datos!!");
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna la informacion del Paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si dos tienen el mismo TrackID
        /// </summary>
        /// <param name="p1">Primer paquetre a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>Retorna ture si el TrackID es el mismo de lo contrario false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si dos no tienen el mismo TrackID
        /// </summary>
        /// <param name="p1">Primer paquetre a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>Retorna ture si el TrackID no es el mismo de lo contrario false</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
