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
    public partial class Balanceado : Form
    {
        public Balanceado()
        {
            InitializeComponent();
            nodo = CreateGraphics();
            arbol = new ArbolBalan(nodo, Font);
            gbEliminar.Enabled = false;
            gbRecorridos.Enabled = false;
            gbDatos.Enabled = false;
            axu = 0;
        }

        public int cantClientes { get; set; }

        int axu,
            i = 0;


        ArbolBalan arbol;
        Graphics nodo;

        public struct datos
        {
            public string Carnet { get; set; }
            public string Carrera { get; set; }
            public double total { get; set; }
        }

        datos[] dato;
        private void Balanceado_Paint(object sender, PaintEventArgs e)
        {
            arbol.MostrarArbol(e, this.BackColor);
        }

        public void Cantidad()
        {
            try
            {
                cantClientes = Convert.ToInt32(txtCantClientes.Text);
                axu = 0;

                if (cantClientes < 0 || txtCantClientes.Text.Length > 8)
                {
                    MessageBox.Show("Cantidad ingresada no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dato = new datos[cantClientes];
                    MessageBox.Show($"Se podran registrar un total de {cantClientes} clientes", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    gbDatos.Enabled = true;
                    gpbCantidad.Enabled = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Cantidad ingresada no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarData(double x)
        {
            bool encontrado = false;

            for (int i = 0; i < dato.Length; i++)
            {
                if (dato[i].total == x)
                {
                    for (int j = i; j < dato.Length - 1; j++)
                    {
                        dato[j].Carnet = dato[j + 1].Carnet;
                        dato[j].Carrera = dato[j + 1].Carrera;
                        dato[j].total = dato[j + 1].total;

                        if (j == dato.Length)
                        {
                            dato[j].Carnet = null;
                            dato[j].Carrera = null;
                            dato[j].total = Convert.ToDouble(""); ;
                        }
                    }
                }
            }

            if (encontrado) i--; axu--;

            dataGridView1.Rows.Clear();

            for (int j = 0; j < axu; j++)
            {
                dataGridView1.Rows.Add(dato[j].Carnet, dato[j].Carrera, dato[j].total);
            }
        }


        public void Insertar()
        {
            if (i == cantClientes)
            {
                MessageBox.Show("Ya no puede ingresar mas elementos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbDatos.Enabled = false;
            }
            else
            {
                try
                {
                    dato[i].Carnet = txtCarnet.Text;
                    dato[i].Carrera = txtCarrera.Text;
                    dato[i].total = (double.Parse(txtPago.Text));

                    if (!arbol.InsertarDatos(dato[i].total))
                    {

                        MessageBox.Show("No se pueden ingresar valores duplicados.\nIngrese su Nombre nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCarnet.Clear();
                        txtCarnet.Focus();

                    }
                    else
                    {
                        dataGridView1.Rows.Add(dato[i].Carnet, dato[i].Carrera, dato[i].total);
                        Refresh();
                        Limpiar();
                        txtCarnet.Focus();
                        i++; axu++;
                    }

                    if (i > 0)
                    {
                        gbRecorridos.Enabled = true;
                    }
                    if (i == cantClientes)
                    {
                        gbEliminar.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Datos erroneos.\nRevisar los datos previamente ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Limpiar()
        {
            txtCarnet.Clear();
            txtCarrera.Clear();
            txtPago.Clear();
        }

        public void Eliminar(double x)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (dato[i].total == x)
                {
                    for (int j = i; j < dato.Length - 1; j++)
                    {
                        dato[j].total = dato[j + 1].total;
                        dato[j].Carnet = dato[j + 1].Carnet;
                        dato[j].Carrera = dato[j + 1].Carrera;

                        if (j == dato.Length)
                        {
                            dato[j].total = Convert.ToDouble(""); ;
                            dato[j].Carnet = null;
                            dato[j].Carrera = null;
                        }
                    }
                }
            }

            axu--;
            i--;

            dataGridView1.Rows.Clear();

            for (int i = 0; i < axu; i++)
            {
                dataGridView1.Rows.Add(dato[i].Carnet, dato[i].Carrera, dato[i].total);
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cantidad();
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            Insertar();
            if (cantClientes != int.Parse(txtCantClientes.Text))
            {
                gbDatos.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);

            if (arbol.Eliminar(x))
            {
                EliminarData(x);
                Refresh();
            }
            else
            {
                MessageBox.Show("No se ha encontrado el nodo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "InOrden")
            {
                arbol.InOrden(Recorridos, lblRecorridos);
            }
            else if (comboBox1.Text == "PosOrden")
            {
                arbol.PosOrden(Recorridos, lblRecorridos);
            }
            else if (comboBox1.Text == "PreOrden")
            {
                arbol.PreOrden(Recorridos, lblRecorridos);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.Show();
        }
    }
}
