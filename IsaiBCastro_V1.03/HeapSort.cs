using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IsaiBCastro_V1._03
{
    class HeapSort
    {
        public int cantidad, i = 0;

        public int[] carnet;
        public string[] nombre;
        public int[] telefono;
        public string[] carrera;
        public double[] pago;
        public HeapSort(int cantidad)
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

        public void Heap_Sort()
        {
            int dat = cantidad - 1;
            string auxnombre;
            double auxtotal;
            int auxCarnet;
            int auxTelefono;
            string auxCarrera;

            for (int i = (dat - 1) / 2; i >= 0; i--)
            {
                sort(i, dat);
            }
            for (int i = dat; i >= 1; i--)
            {
                auxCarnet = carnet[0];
                carnet[0] = carnet[i];
                carnet[i] = auxCarnet;

                auxnombre = nombre[0];
                nombre[0] = nombre[i];
                nombre[i] = auxnombre;

                auxTelefono = telefono[0];
                telefono[0] = telefono[i];
                telefono[i] = auxTelefono;

                auxCarrera = carrera[0];
                carrera[0] = carrera[i];
                carrera[i] = auxCarrera;

                auxtotal = pago[0];
                pago[0] = pago[i];
                pago[i] = auxtotal;

                sort(0, i - 1);
            }
        }

        public void sort(int inicio, int n)
        {
            int f, k;
            bool BAND = false;
            string auxnombre;
            double auxtotal;
            int auxCarnet;
            int auxTelefono;
            string auxCarrera;
            f = inicio;
            k = 2 * f + 1;

            auxCarnet = carnet[f];
            auxnombre = nombre[f];
            auxTelefono = telefono[f];
            auxCarrera = carrera[f];
            auxtotal = pago[f];

            while (k <= n && (!BAND))
            {
                if (k < n)
                {
                    if (pago[k] < pago[k + 1])
                    {
                        k++;
                    }
                }
                if (auxtotal >= pago[k])
                {
                    BAND = true;
                }
                else
                {
                    carnet[f] = carnet[k];
                    nombre[f] = nombre[k];
                    telefono[f] = telefono[k];
                    carrera[f] = carrera[k];
                    pago[f] = pago[k];
                    f = k;
                    k = 2 * f + 1;
                }
            }
            carnet[f] = auxCarnet;
            nombre[f] = auxnombre;
            telefono[f] = auxTelefono;
            carrera[f] = auxCarrera;
            pago[f] = auxtotal;
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
