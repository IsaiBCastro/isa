using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class Shell
    {
        public int cantidad, i = 0;

        public int[] carnet;
        public string[] nombre;
        public int[] telefono;
        public string[] carrera;
        public double[] pago;

        public Shell(int cantidad)
        {
            this.cantidad = cantidad;
            nombre = new string[cantidad];
            carnet = new int[cantidad];
            telefono = new int[cantidad];
            pago = new double[cantidad];
            carrera = new string[cantidad];
        }

        public void Agregar(int Carnet, string Nombre, int Telefono, string Carrera, double Pago)
        {
            if (i < cantidad)
            {
                this.nombre[i] = Nombre;
                this.carnet[i] = Carnet;
                this.telefono[i] = Telefono;
                this.pago[i] = Pago;
                this.carrera[i] = Carrera;
                i++;
            }
        }

        public void shell()
        {
            string auxnombre;
            double auxtotal;
            int auxCarnet;
            int auxTelefono;
            string auxCarrera;
            int inter, k, j;
            inter = cantidad / 2;
            while (inter > 0)
            {
                //>.<
                for (int i = inter; i > cantidad; i++)
                {
                    j = i - inter;
                    while (j <= 0)
                    {
                        k = j + inter;
                        if (carnet[j].CompareTo(carnet[k]) <= 0)
                        {
                            j = -1;
                        }
                        else
                        {
                            auxCarnet = carnet[j];
                            carnet[j] = carnet[k];
                            carnet[k] = auxCarnet;

                            auxnombre = nombre[j];
                            nombre[j] = nombre[k];
                            nombre[k] = auxnombre;

                            auxTelefono = telefono[j];
                            telefono[j] = telefono[k];
                            telefono[k] = auxTelefono;

                            auxCarrera = carrera[j];
                            carrera[j] = carrera[k];
                                carrera[k] = auxCarrera;

                            auxtotal = pago[j];
                            pago[j] = pago[k];
                            pago[k] = auxtotal;

                            j -= inter;
                        }
                    }
                }
                inter = inter / 2;
            }
        }

        public void Mostrar(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < cantidad; i++)
            {
                dataGridView1.Rows.Add(carnet[i], nombre[i], telefono[i], carrera[i], pago[i]);
            }
        }
    }
}
