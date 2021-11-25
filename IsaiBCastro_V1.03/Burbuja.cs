using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class Burbuja
    {
        public int cantidad, i = 0;

        public int[] carnet;
        public string[] nombre;
        public int[] telefono;
        public string[] carrera;
        public double[] pago;
        public Burbuja(int cantidad)
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
                this.carrera[i] = Carrera;
                this.pago[i] = Pago;
                i++;
            }
        }
        public void burbuja()
        {
            string auxnombre;
            double auxtotal;
            int auxCarnet;
            int auxTelefono;
            string auxCarrera;
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = i + 1; j < cantidad; j++)
                {
                    if (pago[i].CompareTo(pago[j]) <= 0)
                    {
                        auxnombre = nombre[i];
                        nombre[i] = nombre[j];
                        nombre[j] = auxnombre;

                        auxCarnet = carnet[i];
                        carnet[i] = carnet[j];
                        carnet[j] = auxCarnet;

                        auxTelefono = telefono[i];
                        telefono[i] = telefono[j];
                        telefono[j] = auxTelefono;

                        auxtotal = pago[i];
                        pago[i] = pago[j];
                        pago[j] = auxtotal;

                        auxCarrera = carrera[i];
                        carrera[i] = carrera[j];
                        carrera[j] = auxCarrera;
                    }
                }
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
