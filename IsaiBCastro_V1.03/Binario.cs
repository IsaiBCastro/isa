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
    public partial class Binario : Form
    {
        public int cantEstudiantes { get; set; }

        int axu, i = 0;


        ArbolBi arbol;
        Graphics nodo;


        public struct datos
        {
            public string Carnet { get; set; }
            public string Nombre { get; set; }
            public string Carrera { get; set; }
            public double total { get; set; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cantidad();
        }

        datos[] dato;

        private void btnDatos_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);

            if (arbol.Eliminar(x))
            {
                Refresh();
                Eliminar(x);
            }
            else return;
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
            dataGridView1.Rows.Clear();

            for (int i = 0; i < axu; i++)
            {
                dataGridView1.Rows.Add(dato[i].Carnet, dato[i].Carrera, dato[i].total);
            }
        }

        public void Cantidad()
        {
            try
            {
                cantEstudiantes = Convert.ToInt32(txtCantClientes.Text);
                axu = cantEstudiantes;

                if (cantEstudiantes < 0 || txtCantClientes.Text.Length > 8)
                {
                    MessageBox.Show("Cantidad ingresada no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dato = new datos[cantEstudiantes];
                    gbDatos.Enabled = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Cantidad ingresada no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Insertar()
        {
            if (i == cantEstudiantes)
            {
                MessageBox.Show("Ya no puede ingresar mas elementos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbDatos.Enabled = false;
            }
            else
            {
                try
                {
                    dato[i].Carnet = txtCarnet.Text;
                    dato[i].Nombre = txtNombre.Text;
                    dato[i].Carrera = txtCarrera.Text;
                    dato[i].total = (double.Parse(txtPago.Text));

                    if (!arbol.InsertarDatos(dato[i].total))
                    {
                        MessageBox.Show("No se pueden ingresar valores duplicados.\nIngrese su precio nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNombre.Clear();
                        txtNombre.Focus();
                    }
                    else
                    {
                        dataGridView1.Rows.Add(dato[i].Carnet, dato[i].Carrera, dato[i].total);
                        Refresh();
                        Limpiar();
                        txtCarnet.Focus();
                        i++;
                    }

                    if (i > 0)
                    {
                        gbRecorridos.Enabled = true;
                    }
                    if (i == cantEstudiantes)
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

        private void Binario_Paint(object sender, PaintEventArgs e)
        {
            arbol.MostrarArbol(e, this.BackColor);
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

        public void Limpiar()
        {
            txtCarnet.Clear();
            txtNombre.Clear();
            txtCarrera.Clear();
            txtPago.Clear();
        }
        public Binario()
        {
            InitializeComponent();
            nodo = CreateGraphics();
            arbol = new ArbolBi(nodo, Font);
            gbEliminar.Enabled = false;
            gbRecorridos.Enabled = false;
            gbDatos.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.Show();
        }
    }
}
