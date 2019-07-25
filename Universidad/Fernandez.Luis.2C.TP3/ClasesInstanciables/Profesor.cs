using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region metodos y constructores

        public Profesor()
        {

            this.clasesDelDia = new Queue<Universidad.EClases>();


            for (int i = 0; i < 2; i++)
            {
                _randomClases();
            }
        }

        static Profesor()
        {
            random = new Random();
            
        }

        
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();

            for (int i = 0; i < 2; i++)
            {
                _randomClases();
            }
           
        }

        /// <summary>
        /// crea un random y añade una clase al docente
        /// </summary>
        private void _randomClases()
        {
            int r;
            r = random.Next(1, 4);

            switch (r)
            {
                case 1:
                    clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 2:
                    clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 3:
                    clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                default:
                    clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }

        /// <summary>
        /// muestra las clases en las que participa el docente
        /// </summary>
        /// <returns></returns>string
        protected override string ParticiparEnClase()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(string.Format("Clases del día:"));
            foreach (Universidad.EClases clases in this.clasesDelDia)
                s.AppendLine(string.Format("{0}", clases.ToString()));
            return s.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();

            s.AppendLine(base.MostrarDatos());
            s.AppendLine(ParticiparEnClase());

            return s.ToString();
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(MostrarDatos());

            //s.AppendLine(ParticiparEnClase());
            return s.ToString();
        }

        #endregion

        #region operadores

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool b = false;
            foreach (Universidad.EClases clases in i.clasesDelDia)
            {
                if (clases == clase)
                    b = true;
            }
            return b;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
