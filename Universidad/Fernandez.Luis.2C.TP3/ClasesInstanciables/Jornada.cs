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

        public Profesor Instructor
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
            s.AppendLine("JORNADA:");
            s.Append(string.Format("Clase de {0} por ", Clase.ToString()));
            s.Append(instructor.ToString());

            s.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in alumnos)
                s.Append(alumno.ToString());

            s.AppendLine("<--------------------------------->");
            return s.ToString();
        }

        /// <summary>
        /// Guarda la informacion en un archivo de texto
        /// </summary>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                bool e;
                Texto txt = new Texto();
                string archivo = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                e = txt.Guardar(archivo, jornada.ToString());              

                return e;
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
            bool e;
            string a = null;
            Texto txt = new Texto();
            string archivo = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            e = txt.Leer(archivo, out a);
            

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
