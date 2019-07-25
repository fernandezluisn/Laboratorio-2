using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Fernandez.Luis.TP4
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();

            PaqueteDAO.NoCargaEnBD += InformaError;
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            
        }

        private void InformaError(string error)
        {
            MessageBox.Show(error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// agrega paquetes y en caso de ser repetidos, devuelve un messagebox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                correo = correo + paquete;
                paq_InformaEstado(paquete, e);
                paquete.InformarEstado += paq_InformaEstado;
                PaqueteDAO.Insertar(paquete);
            }
            catch (TrackingIDRepetidoException t)
            {
                string s = string.Format("El tracking ID {0} ya figura en la lista de envios", mtxtTrackingID.Text);
                t = new TrackingIDRepetidoException(s);
                MessageBox.Show(t.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }           
            catch(Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }

            ActualizarEstados();
        }

        /// <summary>
        /// invoca el evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    ActualizarEstados();
                });
            }
        }      
      

        /// <summary>
        /// Instancia la interfaz, chequea si es null y carga los datos en la sobrecarga
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {         
                      

                if (elemento is null)
            {
                MessageBox.Show("Nada que mostrar.");
            }
            else
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    GuardaString.Guardar(elemento.MostrarDatos(elemento), String.Format("{0}\\salida.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
                }
                catch (System.IO.DirectoryNotFoundException t)
                {                    
                    throw t;
                }
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// limpia los listbox y actualiza el estado de los paquetes para pasarlos al listbox subsiguiente.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach (Paquete paquete1 in correo.Paquetes)
            {
                if ((int)paquete1.Estado == 0)
                {

                    lstEstadoIngresado.Items.Add(paquete1);
                }
                if ((int)paquete1.Estado == 1)
                {
                    lstEstadoEnViaje.Items.Add(paquete1);
                }
                if ((int)paquete1.Estado == 2)
                {
                    lstEstadoEntregado.Items.Add(paquete1);
                }

            }
        }

      

        /// <summary>
        /// cierra los hilos cuando cierro el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosed(object sender, FormClosedEventArgs e)
        {
            correo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
