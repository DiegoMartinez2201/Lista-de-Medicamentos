using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ListaMedicamentos
{
    public partial class FrmDatos : Form
    {
        string Hola;     
        List<Medicamento> medicamentos = new List<Medicamento>();
        public FrmDatos()
        {
            InitializeComponent();
        }
        private void MostrarMedicamentos()
        {
            lstMedicamentos.Items.Clear();
            foreach (var medicamento in medicamentos)
            {
                lstMedicamentos.Items.Add(medicamento.Codigo.ToString() + " - " + medicamento.Nombre + " - " + medicamento.Cantidad.ToString() + " - " + medicamento.PrecioUnitario.ToString("C") + " - " + medicamento.MontoInvertido.ToString("C"));
            }
        }
        private void OrdenarMedicamentos()
        {
            medicamentos = medicamentos.OrderBy(m => m.Nombre).ToList();
            MostrarMedicamentos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double precioUnitario = Convert.ToDouble(txtPrecioUnitario.Text);

            Medicamento medicamento = new Medicamento(codigo, nombre, cantidad, precioUnitario);
            medicamentos.Add(medicamento);

            MostrarMedicamentos();
            LimpiarFormulario();
        }
        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
            txtCodigo.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtBuscarCodigo.Text);

            var medicamento = medicamentos.FirstOrDefault(m => m.Codigo == codigo);

            if (medicamento != null)
            {
                lstMedicamentos.SelectedIndex = medicamentos.IndexOf(medicamento);
            }
            else
            {
                MessageBox.Show("El medicamento con el código ingresado no fue encontrado.");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstMedicamentos.SelectedIndex != -1)
            {
                medicamentos.RemoveAt(lstMedicamentos.SelectedIndex);
                MostrarMedicamentos();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un medicamento a eliminar.");
            }
        }
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OrdenarMedicamentos();
        }
        
    }
}
