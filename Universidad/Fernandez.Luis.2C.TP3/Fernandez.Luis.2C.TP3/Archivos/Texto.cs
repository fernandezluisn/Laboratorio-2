using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        public bool Guardar (string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\"+ archivo);

                sw.WriteLine(datos);

                sw.Close();

                return true;
            }
            catch
            {

                return false;
            }
            

        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\" + archivo);

                datos = sr.ReadToEnd();

                sr.Close();

                return true;
            }
            catch
            {
                datos = null;
                return false;
            }
        }
    }
}
