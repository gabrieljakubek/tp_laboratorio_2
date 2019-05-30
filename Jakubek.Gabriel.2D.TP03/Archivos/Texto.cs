using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(string));
            using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
            {
                serializer.Serialize(writer, datos);
                retorno = true;
            }
            return retorno;
        }

        public bool Leer(string archivo, out string dato)
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(string));
            using (XmlTextReader reader = new XmlTextReader(archivo))
            {
                dato = (string)serializer.Deserialize(reader);
                retorno = true;
            }
            return retorno;
        }
    }
}
