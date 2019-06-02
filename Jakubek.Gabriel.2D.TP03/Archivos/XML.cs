using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Archivos
{
    public class XML<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            BinaryFormatter binary = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(archivo, FileMode.Create))
                {
                    binary.Serialize(stream, datos);
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return retorno;
        }

        public bool Leer(string archivo, out T dato)
        {
            bool retorno = false;
            BinaryFormatter binary = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(archivo, FileMode.Open))
                {
                    dato = (T)binary.Deserialize(stream);
                    retorno = true;
                }
            }
            catch (Exception ex)
            { 
                throw new ArchivosException(ex);
            }

            return retorno;
        }
    }
}
