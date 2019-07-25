using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{


    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformarEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;


        #region propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion


        #region metodos

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega = direccionEntrega;
            this.Estado = 0;
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TrackingID == p2.TrackingID)
                return true;
            else
                return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


        /// <summary>
        /// devuelve los datos de ID y entrega de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            string s;
            s = string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            return s;
        }


        /// <summary>
        /// espera 4 segundos, cambia el estado de envío del paquete, informa el cambio y lo agrega a una base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            EventArgs eventArgs = new EventArgs();
            for (int i = (int)this.Estado; i < 3; i++)
            {
                Thread.Sleep(4000);
                if (i < 2)
                    this.Estado++;

                this.InformarEstado(this.Estado, eventArgs);
            }

            PaqueteDAO.Insertar(this);
        }


        /// <summary>
        /// devulve datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(this.MostrarDatos(this));
            return s.ToString();
        }

        #endregion


    }
}
