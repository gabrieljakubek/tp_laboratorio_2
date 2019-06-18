using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Metodo para guardar un texto en un archivo
        /// </summary>
        /// <param name="texto">Lo que se desea guardar</param>
        /// <param name="arcrivo">Nombre del archivo donde se guardara</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string arcrivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + arcrivo + ".txt"))
                {
                    sw.WriteLine(texto);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
