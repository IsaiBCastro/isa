using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class InsercionDirecta
    {
        public int cantidad, i = 0;

        public int[] carnet;
        public string[] nombre;
        public int[] telefono;
        public string[] carrera;
        public double[] pago;

        public InsercionDirecta(int cantidad)
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

        public void Insercion()
        {
            for (int i = 0; i < cantidad; i++)
            {
                int Carnet = carnet[i];
                string Nombre = nombre[i];
                int Telefono = telefono[i];
                string Carrera = carrera[i];
                double Pago = pago[i];

                int j = i - 1;
                while ((j >= 0) && carnet[j].CompareTo(carnet[i]) < 0)
                {
                    carnet[j + 1] = carnet[j];
                    nombre[j + 1] = nombre[j];
                    telefono[j + 1] = telefono[j];
                    carrera[j + 1] = carrera[j];
                    pago[j + 1] = pago[j];
                    j--;
                }
                carnet[j + 1] = Carnet;
                nombre[j + 1] = Nombre;
                telefono[j + 1] = Telefono;
                carrera[j + 1] = Carrera;
                pago[j + 1] = Pago;
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
