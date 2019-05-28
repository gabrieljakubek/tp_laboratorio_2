using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Atributos
        private string mensajeBase;
        #endregion

        public DniInvalidoException() : this("DNI Invalido", null)
        { }
        public DniInvalidoException(Exception e) : this("DNI invalido", e)
        { }
        public DniInvalidoException(string mensaje) : this(mensaje, null)
        { }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
            this.mensajeBase = mensaje;
        }
    }
}
