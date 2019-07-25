using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos
{
    public class Xml<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool guardado = true;

            XmlTextWriter writer;
            XmlSerializer ser;



            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);

                ser = new XmlSerializer(typeof(T));

                ser.Serialize(writer, datos);

                writer.Close();

            }
            catch (Exception e)
            {
                guardado = false;

                throw new ArchivosException(e);
            }



            return guardado;
        }

        public bool Leer(string archivo, out T datos)
        {

            bool leido = true;


            XmlTextReader reader;
            XmlSerializer ser;


            try
            {
                reader = new XmlTextReader(archivo);

                ser = new XmlSerializer(typeof(T));

                datos = (T)ser.Deserialize(reader);

                reader.Close();
            }
            catch (Exception e)
            {

                leido = false;

                throw new ArchivosException(e);

            }


            return leido;

        }
    }
}
