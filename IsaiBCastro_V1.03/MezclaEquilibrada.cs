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
    public partial class MezclaEquilibrada : Form
    {
        int cant, i;
        public int Rango { get; set; }
        public static int cantidad { get; set; }

        private static StreamReader lec_A, lec_A1, lec_A2, lec_A3;

        static StreamWriter A_Es;
        static StreamWriter A1_Es;
        static StreamWriter A2_Es;
        static StreamWriter A3_Es;

        public struct Usuarios { public int Prestamo; }

        Usuarios[] Usuario;
        public MezclaEquilibrada()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            cant = int.Parse(txtCant.Text);
            Usuario = new Usuarios[cant];
            A_Es = new StreamWriter("A.txt");
            txtCant.Enabled = false;
            btnIniciar.Enabled = false;
            txtNum.Focus();
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
                mezclaEquilibrada(lec_A, A_Es, lec_A1, A1_Es, lec_A2, A2_Es, lec_A3, A3_Es);
                MessageBox.Show("Los datos han sido ordenados");
                lec_A2 = new StreamReader("A.txt");
                Process.Start("A.txt");
                lec_A2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido lo siguiente: " + ex, "Errores en el algoritmo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static void mezclaEquilibrada(StreamReader lec_A, StreamWriter A_Es, StreamReader lec_A1, StreamWriter A1_Es, StreamReader lec_A2, StreamWriter A2_Es, StreamReader lec_A3, StreamWriter A3_Es)
        {
            bool bandera;

            lec_A = new StreamReader("A.txt");
            A2_Es = new StreamWriter("A2.txt");
            A3_Es = new StreamWriter("A3.txt");

            particionInicial(lec_A, A2_Es, A3_Es);

            lec_A2 = new StreamReader("A2.txt");
            lec_A3 = new StreamReader("A3.txt");
            A_Es = new StreamWriter("A.txt");
            A1_Es = new StreamWriter("A1.txt");

            fusionParticion(lec_A2, lec_A3, A_Es, A1_Es);
            bandera = false;

            while (EstaVacio(lec_A1, "A1.txt") == false || EstaVacio(lec_A3, "A3.txt") == false)
            {
                if (bandera == true)
                {

                    lec_A2 = new StreamReader("A2.txt");
                    lec_A3 = new StreamReader("A3.txt");
                    A_Es = new StreamWriter("A.txt");
                    A1_Es = new StreamWriter("A1.txt");

                    fusionParticion(lec_A2, lec_A3, A_Es, A1_Es);
                    bandera = false;
                }
                else
                {

                    lec_A = new StreamReader("A.txt");
                    lec_A1 = new StreamReader("A1.txt");
                    A2_Es = new StreamWriter("A2.txt");
                    A3_Es = new StreamWriter("A3.txt");

                    fusionParticion(lec_A, lec_A1, A2_Es, A3_Es);
                    bandera = true;
                }
            }
        }
        public static void particionInicial(StreamReader Lectura_Principal, StreamWriter Auxiliar_A2, StreamWriter Auxiliar_A3)
        {


            int auxiliar = 0, puntero = 0;
            bool bandera;

            puntero = Convert.ToInt32(Lectura_Principal.ReadLine());
            Auxiliar_A2.WriteLine(puntero);
            bandera = true;
            auxiliar = puntero;

            while (!Lectura_Principal.EndOfStream)
            {
                puntero = Convert.ToInt32(Lectura_Principal.ReadLine());

                if (puntero >= auxiliar)
                {
                    auxiliar = puntero;

                    if (bandera == true)
                    {
                        Auxiliar_A2.WriteLine(puntero);
                    }
                    else
                    {
                        Auxiliar_A3.WriteLine(puntero);
                    }
                }
                else
                {
                    auxiliar = puntero;

                    if (bandera == true)
                    {
                        Auxiliar_A3.WriteLine(puntero);
                        bandera = false;
                    }
                    else
                    {
                        Auxiliar_A2.WriteLine(puntero);
                        bandera = true;
                    }
                }
            }

            Lectura_Principal.Close();
            Auxiliar_A2.Close();
            Auxiliar_A3.Close();
        }
        public static void fusionParticion(StreamReader AA, StreamReader AB, StreamWriter AC, StreamWriter AD)
        {

            int auxiliar = 0, puntero_1 = 0, puntero_2 = 0;
            bool bandera_1, bandera_2, bandera_3;

            bandera_1 = true;
            bandera_2 = true;
            bandera_3 = true;


            auxiliar = -100;

            while ((!AA.EndOfStream || bandera_1 == false) && (!AB.EndOfStream || bandera_2 == false))
            {
                if (bandera_1 == true)
                {
                    puntero_1 = int.Parse(AA.ReadLine());
                    bandera_1 = false;
                }

                if (bandera_2 == true)
                {
                    puntero_2 = int.Parse(AB.ReadLine());
                    bandera_2 = false;
                }

                if (puntero_1 < puntero_2)
                {
                    if (puntero_1 >= auxiliar)
                    {
                        if (bandera_3 == true)
                        {
                            AC.WriteLine(puntero_1);
                        }
                        else
                        {
                            AD.WriteLine(puntero_1);
                        }

                        bandera_1 = true;
                        auxiliar = puntero_1;

                    }
                    else
                    {
                        if (bandera_3 == true)
                        {
                            AC.WriteLine(puntero_2);
                            bandera_3 = false;
                        }
                        else
                        {
                            AD.WriteLine(puntero_2);
                            bandera_3 = true;
                        }

                        bandera_2 = true;
                        auxiliar = -32768;
                    }
                }
                else
                {
                    if (puntero_2 >= auxiliar)
                    {
                        if (bandera_3 == true)
                        {
                            AC.WriteLine(puntero_2);
                        }
                        else
                        {
                            AD.WriteLine(puntero_2);
                        }

                        bandera_2 = true;
                        auxiliar = puntero_2;

                    }
                    else
                    {
                        if (bandera_3 == true)
                        {
                            AC.WriteLine(puntero_1);
                            bandera_3 = false;
                        }
                        else
                        {
                            AD.WriteLine(puntero_1);
                            bandera_3 = true;
                        }

                        bandera_1 = true;
                        auxiliar = -32768;
                    }
                }
            }

            if (bandera_1 == false)
            {
                if (bandera_3 == true)
                {
                    AC.WriteLine(puntero_1);

                    while (!AA.EndOfStream)
                    {
                        puntero_1 = Convert.ToInt32(AA.ReadLine());
                        AC.WriteLine(puntero_1);
                    }
                }
                else
                {
                    AD.WriteLine(puntero_1);

                    while (!AA.EndOfStream)
                    {
                        puntero_1 = Convert.ToInt32(AA.ReadLine());
                        AD.WriteLine(puntero_1);
                    }
                }
            }

            if (bandera_2 == false)
            {
                if (bandera_3 == true)
                {
                    AC.WriteLine(puntero_2);

                    while (!AB.EndOfStream)
                    {
                        puntero_2 = Convert.ToInt32(AB.ReadLine());
                        AC.WriteLine(puntero_2);
                    }
                }
                else
                {
                    AD.WriteLine(puntero_2);

                    while (!AB.EndOfStream)
                    {
                        puntero_2 = Convert.ToInt32(AB.ReadLine());
                        AD.WriteLine(puntero_2);
                    }
                }
            }

            AA.Close();
            AB.Close();
            AC.Close();
            AD.Close();
        }
        public static bool EstaVacio(StreamReader Archivo, string nombreArchivo)
        {
            cantidad = 0;

            Archivo = new StreamReader(nombreArchivo);

            while (!Archivo.EndOfStream)
            {
                string cadena = Archivo.ReadLine();
                cantidad++;
            }

            Archivo.Close();

            bool vacio = (cantidad == 0) ? true : false;
            return vacio;

        }
    }
}

