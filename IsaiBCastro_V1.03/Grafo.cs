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
    public partial class Grafo : Form
    {
        public long[,] Matriz_Pesos;
        public int Contador1 = 0, Contador2 = 1;
        public int Numero;
        Camino_Corto CaminoC = new Camino_Corto();

        private void button1_Click(object sender, EventArgs e)
        {
            Numero = int.Parse(txtNumeroVertices.Text);
            Matriz_Pesos = new long[int.Parse(txtNumeroVertices.Text), int.Parse(txtNumeroVertices.Text)];
            MessageBox.Show("Prosiga a ingresar la distancia de vertices");
            label7.Text = Convert.ToString(Contador1 + 1); label8.Text = Convert.ToString(Contador2 + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "NO")
            {
                MessageBox.Show("No Esxiste una distancia entre los vertices " + (Contador1 + 1) + " y" + (Contador2 + 1));
                comboBox1.Text = "";
                Matriz_Pesos[Contador1, Contador2] = 9999999;
                Contador2++;
                if (Contador1 == Contador2)
                {
                    Matriz_Pesos[Contador1, Contador2] = 0;
                    Contador2++;
                }
                if (Contador2 != Numero)
                {
                    label8.Text = Convert.ToString(Contador2 + 1);
                }
                else
                {
                    Contador2 = 0;
                    MessageBox.Show("se han  completado  las distancias del vertice " + (Contador1 + 1) + " prosiga con el sigiente vertice");
                    label8.Text = Convert.ToString(Contador2 + 1);
                    Contador1++;
                    if (Contador1 == Numero)
                    {
                        Contador1 = 0;
                        MessageBox.Show("se ha completado la matriz de instancias");
                    }
                    else
                    {
                        label7.Text = Convert.ToString(Contador1 + 1);
                    }
                }
            }
            else
            {
                comboBox1.Text = "";
                label9.Text = Convert.ToString(Contador1 + 1); label10.Text = Convert.ToString(Contador2 + 1);
                MessageBox.Show("Si esxiste distancia del vertice " + (Contador1 + 1) + " al vertice" + (Contador2 + 1) + " , prosiga a ingresar la distancia");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Matriz_Pesos[Contador1, Contador2] = int.Parse(textBox2.Text);
            textBox2.Clear(); MessageBox.Show("Distancia ingresada");
            Contador2++;
            if (Contador1==Contador2)
            {
                Matriz_Pesos[Contador1, Contador2] = 0;
                Contador2++;
            }
            if (Contador2!=Numero)
            {
                label8.Text = Convert.ToString(Contador2 + 1);
            }
            else
            {
                Contador2 = 0;
                MessageBox.Show("se han completado las distancias del vertice " + (Contador1 + 1) + " Prosiga con el sigiente vertice");
                label8.Text = Convert.ToString(Contador2 + 1);
                Contador1++;
                if (Contador1==Numero)
                {
                    Contador1 = 0;
                    MessageBox.Show("Se ha completado la matriz de distancias");
                }
                else
                {
                    label8.Text = Convert.ToString(Contador1 + 1);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = CaminoC.Algoritmo_floyd(Matriz_Pesos, Numero);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.Show();
        }

        public Grafo()
        {
            InitializeComponent();
        }

    }
}
