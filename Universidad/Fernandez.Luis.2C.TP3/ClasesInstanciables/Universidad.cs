using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #region propiedades e indexador
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

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }

            set
            {
                this.jornadas[i] = value;
            }
        }
        #endregion

        #region operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool b = false;

            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                {
                    b = true;
                    break;
                }
            }

            return b;

        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool b = false;
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }
            return u;
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {

            Profesor p = null;
            Jornada jornada = null;

            foreach (Profesor prof in u.profesores)
            {
                if (prof == clase)
                {
                    p = prof;

                    break;
                }
            }

            if (Object.ReferenceEquals(p, null))
            {
                throw new SinProfesorException();
            }

            jornada = new Jornada(clase, p);

            foreach (Alumno alumno in u.alumnos)
            {
                if (alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }

            u.Jornadas.Add(jornada);
            return u;
        }

        public static Profesor operator ==(Universidad u, EClases clases)
        {
            
                Profesor p = new Profesor();

                foreach (Profesor prof in u.profesores)
                {
                    if (prof == clases)
                    {
                        p = prof;
                        break;
                    }
                }
            if (Object.ReferenceEquals(p, null))
            {
                throw new SinProfesorException();
            }
            else
                return p;




        }

        public static Profesor operator !=(Universidad u, EClases clases)
        {


            Profesor p = null;
            foreach (Profesor prof in u.profesores)
            {
                if (prof != clases)
                {
                    p = prof;
                    break;
                }
            }
            return p;


        }

        #endregion


        #region metodos y constructores

        public Universidad()
        {
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            
        }

        /// <summary>
        /// muestra los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder s = new StringBuilder();

            foreach (Jornada jornada in uni.jornadas)
            {
                s.AppendLine(jornada.ToString());
            }
           
          
            return s.ToString();
        }

        public override string ToString()
        {
            
            StringBuilder s = new StringBuilder();

            s.AppendLine(MostrarDatos(this));
            

            return s.ToString();
        }

        /// <summary>
        /// guarda en un xml la información de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>bool
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                string archivo = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                xml.Guardar(archivo, uni);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Universidad Leer()
        {
            Universidad uni = null;

            Xml<Universidad> xml = new Xml<Universidad>();
            string archivo = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            xml.Leer(archivo, out uni);            
            return uni;
        }

        #endregion
    }
}
