using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// guarda en un archivo de texto los datos de los paquetes
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool seGuardo = true;

            try
            {
                StreamWriter streamWriter = new StreamWriter(archivo, true);
                streamWriter.WriteLine(texto);
                streamWriter.Close();
                
            }
           
            catch (Exception e)
            {
                seGuardo = false;
                throw e;
            }
            return seGuardo;
        }
    }
}
