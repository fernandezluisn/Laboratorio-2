using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.IO;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        private Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region metodos y constructores

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.instructor = instructor;
            this.Clase = clase;
            
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("Jornada:");
            s.Append(string.Format("Clase de {0} por ", Clase.ToString()));
            
            foreach (Alumno alumno in alumnos)
                s.AppendLine(alumno.ToString());
            return s.ToString();
        }

        /// <summary>
        /// Guarda la informacion en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>bool
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter("C:\\archivo.txt");
                streamWriter.WriteLine(jornada.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Lee la información de un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {

            string a;
            StringReader stringReader = new StringReader("C:\\archivo.txt");
            a = stringReader.ReadToEnd();

            return a;
        }



        #endregion

        #region operadores

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool b = false;
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static bool operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
