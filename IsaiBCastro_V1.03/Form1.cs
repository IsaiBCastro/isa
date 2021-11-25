using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    public partial class Form1 : Form
    {
        public int cant, i = 0;
        public struct Datos
        {
            public int Carnet;
            public string Nombre;
            public int Telefono;
            public string Carrera;
            public double Pago;
        }
        Datos[] Estudiantes;
        public Form1()
        {
            InitializeComponent();
            btnMDirec.Enabled = false;
            btnIntercalacion.Enabled = false;
            btnMEqui.Enabled = false;

            txtCarnet.Enabled = false;
            txtCarrera.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtPagoMatricula.Enabled = false;
            txtCantidad.Enabled = false;
            txtBuscar.Enabled = false;
            txtBHash.Enabled = false;
            comboBox2.Enabled = false;
            btnAceptar.Enabled = false;
            btnSecuencial.Enabled = false;
            btnHash.Enabled = false;
            btnAgregar.Enabled =    false;
            btnOrdenar.Enabled = false;

        }
        private void limpiar()
        {
            txtCarnet.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCarrera.Clear();
            txtPagoMatricula.Clear();
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = (Convert.ToInt32(txtCantidad.Text) - 1).ToString();

                Estudiantes[i].Carnet = int.Parse(txtCarnet.Text);
                Estudiantes[i].Nombre = txtNombre.Text;
                Estudiantes[i].Telefono = int.Parse(txtTelefono.Text);
                Estudiantes[i].Carrera = txtCarrera.Text;
                Estudiantes[i].Pago = double.Parse(txtPagoMatricula.Text);

                dataGridView1.Rows.Add(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);

            limpiar();
            i++;
            txtCarnet.Focus();
            if (i == cant)
            {
                MessageBox.Show("Ha llegado al limite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || int.Parse(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("Ingrese un valor valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Clear();
                txtCantidad.Focus();
            }
            else
            {
                cant = int.Parse(txtCantidad.Text);
                Estudiantes = new Datos[cant];
                btnAceptar.Enabled = false;
                txtCarnet.Focus();
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Método Burbuja")
            {
                Burbuja burbuja = new Burbuja(cant);

                for (int i = 0; i < cant; i++)
                {
                    burbuja.Agregar(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
                }

                burbuja.burbuja();
                burbuja.Mostrar(dataGridView1);
            }

            if (comboBox2.Text == "QuickSort")
            {
                QuickSort quick = new QuickSort(cant);

                for (int i = 0; i < cant; i++)
                {
                    quick.Agregar(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
                }

                quick.quicksort();
                quick.Mostrar(dataGridView1);
            }

            if (comboBox2.Text == "Inserción Directa")
            {
                InsercionDirecta baraja = new InsercionDirecta(cant);
                {
                    for (int i = 0; i < cant; i++)
                    {
                        baraja.Agregar(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
                    }
                    baraja.Insercion();
                    baraja.Mostrar(dataGridView1);
                }
            }

            if (comboBox2.Text == "Heap Sort")
            {
                HeapSort heap = new HeapSort(cant);
                for (int i = 0; i < cant; i++)
                {
                    heap.Agregar(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
                }
                heap.Heap_Sort();
                heap.Mostrar(dataGridView1);
            }

            if (comboBox2.Text == "Seleccion Directa")
            {
                SeleccionDirecta selecion = new SeleccionDirecta(cant);
                for (int i = 0; i < cant; i++)
                {
                    selecion.Agregar(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
                }

                selecion.Selec();
                selecion.Mostrar(dataGridView1);
            }

            if (comboBox2.Text == "Shell")
            {
                Shell shell = new Shell(cant);

                for (int i = 0; i < cant; i++)
                {
                    shell.Agregar(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
                }

                shell.shell();
                shell.Mostrar(dataGridView1);
            }
        }

        private void btnSecuencial_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtBuscar.Text);
                i = 0;
                while (i <= cant - 1 && (Estudiantes[i].Carnet).CompareTo(x) != 0)
                {
                    i++;
                }
                if (i > cant - 1)
                {
                    MessageBox.Show("No se encuentra lo que esta buscando", "ERRR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    /*
                    string texto = "<html>" +
                   "<span style=\"font-size:14.5pt;font-family:Segoe UI Semibold;\">  " + Estudiantes[i].Carnet + "</span>" +
                   "<span style=\"font-size:10.5pt;\"><i>  </i></span>" +
                   "<br><span style=\"font-size:10pt;\"> " + Estudiantes[i].Nombre + " días,  Telefono " + Estudiantes[i].Telefono + " Hasta " + Estudiantes[i].Carrera + "</span>" +
                   "<br><span style=\"color:" + Estudiantes[i].Pago + ";font-size:14.5pt;\"> paga: " + string.Format("{0:C2}", Estudiantes[i].Pago) + "</span>";
                    MessageBox.Show(string.Format(texto), "Busqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                */
                    MessageBox.Show(string.Format("\n Informacion:\n \n- Carnet:{0} \n- Nombre: {1} \n- Telefono: {2} \n- Carrera: {3} \n- Pago Matricula: {4}",
                           Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago), "Busqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede realizar la operacion");
            }
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtBHash.Text);
            Hash hash = new Hash(cant);
            for (int i = 0; i < cant; i++)
            {
                hash.entra(Estudiantes[i].Carnet, Estudiantes[i].Nombre, Estudiantes[i].Telefono, Estudiantes[i].Carrera, Estudiantes[i].Pago);
            }
            hash.PruebaLineal(x);
        }

        private void btnIntercalacion_Click(object sender, EventArgs e)
        {
            IntercalacionDeArchivos inter = new IntercalacionDeArchivos();
            inter.Show();
            this.Hide();
        }

        private void btnMDirec_Click(object sender, EventArgs e)
        {
            MesclaDirecta MDirec = new MesclaDirecta();
            MDirec.Show();
            this.Hide();
        }

        private void ordenamientoExternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMDirec.Enabled = true;
            btnIntercalacion.Enabled = true;
            btnMEqui.Enabled = true;
        }

        private void ordenamientoYBusquedaInternaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCarnet.Enabled = true;
            txtCarrera.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtPagoMatricula.Enabled = true;
            txtCantidad.Enabled = true;
            txtBuscar.Enabled = true;
            txtBHash.Enabled = true;
            comboBox2.Enabled = true;
            btnAceptar.Enabled = true;
            btnSecuencial.Enabled = true;
            btnHash.Enabled = true;
            btnAgregar.Enabled = true;
            btnOrdenar.Enabled = true;
            txtCantidad.Focus();
        }

        private void grafosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafo gra = new Grafo();
            this.Hide();
            gra.Show();
        }

        private void binarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Binario bin = new Binario();
            this.Hide();
            bin.Show();
        }

        private void balanceadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Balanceado baln = new Balanceado();
            this.Hide();
            baln.Show();
        }

        private void btnMEqui_Click(object sender, EventArgs e)
        {
            MezclaEquilibrada MEqui = new MezclaEquilibrada();
            MEqui.Show();
            this.Hide();
        }
    }
}
