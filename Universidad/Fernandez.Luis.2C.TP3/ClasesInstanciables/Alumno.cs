using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region metodos y constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(base.MostrarDatos());
            s.AppendLine(string.Format("Estado de cuenta: {0}", this.estadoCuenta.ToString()));
            s.AppendLine(ParticiparEnClase());
            return s.ToString();
        }

        /// <summary>
        /// Devuelve una cadena con las clases que toma el alumno.
        /// </summary>
        /// <returns></returns>string
        protected override string ParticiparEnClase()
        {
            StringBuilder s = new StringBuilder();                  
            s.AppendLine(string.Format("Toma clase de {0}", this.claseQueToma.ToString()));
            return s.ToString();
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(MostrarDatos());            
            return s.ToString();
        }

        #endregion

        #region operadores

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
                return true;
            else
                return false;
        }

        #endregion
    }
}
