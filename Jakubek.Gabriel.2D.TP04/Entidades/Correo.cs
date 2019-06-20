using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructores
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna los datos de los paquetes cargados
        /// </summary>
        /// <param name="elementos">Lista de los paquetes</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(String.Format("{0} ({1})", paquete.MostrarDatos(paquete), paquete.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Cierra los hilos que todavia estén vivios
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un paquete si es qué no se encuentra en la lista todavia
        /// </summary>
        /// <param name="c">Correo al que se desea agregar el paquete</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            Thread hilo;
            try
            {
                foreach (Paquete paquete in c.paquetes)
                {
                    if (paquete == p)
                    {
                        throw new TrackingIdRepetidoException("El TrackID " + p.TrackingID + " ya se encuentra ingresado en el sistema");
                    }
                }
                c.paquetes.Add(p);
                hilo = new Thread(p.MockCicloDeVida);
                hilo.Start();
                c.mockPaquetes.Add(hilo);
                return c;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion
    }
}
