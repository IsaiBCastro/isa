using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace IsaiBCastro_V1._03
{
    public partial class MesclaDirecta : Form
    {
        int cant, i;
        static StreamReader A_Lec;
        static StreamReader A1_Lec;
        static StreamReader A2_Lec;

        static StreamWriter A_Es;
        static StreamWriter A1_Es;
        static StreamWriter A2_Es;

        public struct Usuarios { public int Prestamo; }
        Usuarios[] Usuario;
        public MesclaDirecta()
        {
            InitializeComponent();
            cant = 0;
            i = 0;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            cant = int.Parse(txtCant.Text);
            Usuario = new Usuarios[cant];
            A_Es = new StreamWriter("A.txt");
            txtCant.Enabled = false;
            btnIniciar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario[i].Prestamo = int.Parse(txtNum.Text);
                A_Es.WriteLine(txtNum.Text);
                A_Es.Flush();
                Lista.Items.Add(Usuario[i].Prestamo);
                i++;
                MessageBox.Show("Se guardo el dato");
                txtNum.Clear();
                txtNum.Focus();
                btnOrdenar.Enabled = true;
                txtCant.Text = (Convert.ToInt32(txtCant.Text) - 1).ToString();
                if (i == cant)
                {
                    MessageBox.Show("Llego al limite");
                    txtNum.Clear();
                    txtNum.Enabled = false;
                    btnGuardar.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Llego al limite");
                txtNum.Clear();
                txtNum.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                A_Es.Close();

                Mezcla(A_Lec, A_Es, A1_Lec, A1_Es, A2_Lec, A2_Es);

                MessageBox.Show("Los datos han sido ordenados");
                A1_Lec = new StreamReader("A.txt");
                Process.Start("A.txt");
                A1_Lec.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido lo siguiente: " + ex);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static int obtener(StreamReader Principal)
        {
            Principal = new StreamReader("A.txt");
            int cantidad = 0;
            while (!Principal.EndOfStream)
            {
                string cadena = Principal.ReadLine();
                cantidad++;
            }
            Principal.Close();
            return cantidad;
        }

        public static void Mezcla(StreamReader A_Lec, StreamWriter A_Es, StreamReader A1_Lec, StreamWriter A1_Es, StreamReader A2_Lec, StreamWriter A2_Es)
        {
            int part = 1, vueltas = obtener(A_Lec);
            while (part <= vueltas)
            {
                A_Lec = new StreamReader("A.txt");
                A1_Es = new StreamWriter("A1.txt");
                A2_Es = new StreamWriter("A2.txt");

                Particionar(A_Lec, A1_Es, A2_Es, part);

                A_Lec.Close();
                A1_Es.Close();
                A2_Es.Close();

                A_Es = new StreamWriter("A.txt");
                A1_Lec = new StreamReader("A1.txt");
                A2_Lec = new StreamReader("A2.txt");

                Fusionar(A_Es, A1_Lec, A2_Lec, part);

                part *= 2;
            }

            Console.WriteLine("\n**** Fin del archivo ****");
        }
        public static void Particionar(StreamReader A_Lec, StreamWriter A1_Es, StreamWriter A2_Es, int part)
        {
            int puntero = 0;

            while (!A_Lec.EndOfStream)
            {
                int puntero_F1 = 0;
                while (puntero_F1 < part && !A_Lec.EndOfStream)
                {
                    puntero = Convert.ToInt32(A_Lec.ReadLine());
                    A1_Es.WriteLine(puntero);
                    puntero_F1++;
                }

                int puntero_F2 = 0;
                while (puntero_F2 < part && !A_Lec.EndOfStream)
                {
                    puntero = Convert.ToInt32(A_Lec.ReadLine());
                    A2_Es.WriteLine(puntero);
                    puntero_F2++;
                }
            }
        }

        public static void Fusionar(StreamWriter A_Es, StreamReader A1_Lec, StreamReader A2_Lec, int part)
        {
            bool bandera_1 = true, bandera_2 = true;

            int read_1 = 0, read_2 = 0;


            if (!A1_Lec.EndOfStream)
            {
                read_1 = Convert.ToInt32(A1_Lec.ReadLine());
                bandera_1 = false;
            }

            if (!A2_Lec.EndOfStream)
            {
                read_2 = Convert.ToInt32(A2_Lec.ReadLine());
                bandera_2 = false;
            }

            while ((!A1_Lec.EndOfStream || bandera_1 == false) && (!A2_Lec.EndOfStream || bandera_2 == false))
            {
                int puntero_1 = 0, puntero_2 = 0;

                while ((puntero_1 < part && bandera_1 == false) && (puntero_2 < part && bandera_2 == false))
                {
                    if (read_1 <= read_2)
                    {
                        A_Es.WriteLine(read_1);
                        bandera_1 = true; puntero_1++;

                        if (!A1_Lec.EndOfStream)
                        {
                            read_1 = Convert.ToInt32(A1_Lec.ReadLine());
                            bandera_1 = false;
                        }
                    }
                    else
                    {
                        A_Es.WriteLine(read_2);
                        bandera_2 = true; puntero_2++;
                        if (!A2_Lec.EndOfStream)
                        {
                            read_2 = Convert.ToInt32(A2_Lec.ReadLine());
                            bandera_2 = false;
                        }
                    }
                }

                while (puntero_1 < part && bandera_1 == false)
                {
                    A_Es.WriteLine(read_1);
                    bandera_1 = true; puntero_1++;

                    if (!A1_Lec.EndOfStream)
                    {
                        read_1 = Convert.ToInt32(A1_Lec.ReadLine());
                        bandera_1 = false;
                    }
                }

                while (puntero_2 < part && bandera_2 == false)
                {
                    A_Es.WriteLine(read_2);
                    bandera_2 = true; puntero_2++;

                    if (!A2_Lec.EndOfStream)
                    {
                        read_2 = Convert.ToInt32(A2_Lec.ReadLine());
                        bandera_2 = false;
                    }
                }

            }

            if (bandera_1 == false) { A_Es.WriteLine(read_1); }

            if (bandera_2 == false) { A_Es.WriteLine(read_2); }

            while (!A1_Lec.EndOfStream)
            {
                read_1 = Convert.ToInt32(A1_Lec.ReadLine());
                A_Es.WriteLine(read_1);
            }

            while (!A2_Lec.EndOfStream)
            {
                read_2 = Convert.ToInt32(A2_Lec.ReadLine());
                A_Es.WriteLine(read_2);
            }

            A_Es.Close();
            A1_Lec.Close();
            A2_Lec.Close();
        }

    }
}
