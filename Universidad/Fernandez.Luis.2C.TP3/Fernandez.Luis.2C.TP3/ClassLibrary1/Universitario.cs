using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region metodos

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public override bool Equals(object obj)
        {
          if (obj is Universitario)
            return true;
          else
            return false;
        }

        /// <summary>
        /// Devuelve una cadena de texto con los datos del universitario
        /// </summary>
        /// <returns></returns>string
        protected virtual string MostrarDatos()
        {
          StringBuilder s = new StringBuilder();
          s.AppendLine(base.ToString());
          s.AppendLine(string.Format("Legajo número: {0}",this.legajo.ToString()));
          return s.ToString();
        }

        abstract protected string ParticiparEnClase();
        

        



        #endregion

        #region operadores

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            return true;
            else
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        #endregion
    }
}
