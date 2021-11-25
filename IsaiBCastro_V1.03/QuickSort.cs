using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class QuickSort
    {
        public int cantidad, i = 0;

        public int[] carnet;
        public string[] nombre;
        public int[] telefono;
        public string[] carrera;
        public double[] pago;
        public QuickSort(int cantidad)
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
        public void quicksort()
        {
            rapidoRecursivo();
        }

        void rapidoRecursivo()
        {
            int i = 0, f = cantidad - 1;
            reduceRecursivo(i, f);
        }

        void reduceRecursivo(int ini, int fin)
        {

            int izq, der, pos;
            string auxnombre;
            double auxtotal;
            int auxCarnet;
            int auxTelefono;
            string auxCarrera;
            bool band = true;

            izq = ini; der = fin; pos = ini;

            while (band == true)
            {
                band = false;

                while (pago[pos].CompareTo(pago[der]) <= 0 && pos != der)
                {
                    der--;
                }

                if (pos != der)
                {
                    auxnombre = nombre[pos];
                    nombre[pos] = nombre[der];
                    nombre[der] = auxnombre;

                    auxCarnet = carnet[pos];
                    carnet[pos] = carnet[der];
                    carnet[der] = auxCarnet;

                    auxTelefono = telefono[pos];
                    telefono[pos] = telefono[der];
                    telefono[der] = auxTelefono;

                    auxtotal = pago[pos];
                    pago[pos] = pago[der];
                    pago[der] = auxtotal;

                    auxCarrera = carrera[pos];
                    carrera[pos] = carrera[der];
                    carrera[der] = auxCarrera;


                    pos = der;

                    while (pago[pos].CompareTo(pago[izq]) >= 0 && pos != izq)
                    {
                        izq++;
                    }

                    if (pos != izq)
                    {
                        band = true;

                        auxnombre = nombre[pos];
                        nombre[pos] = nombre[izq];
                        nombre[izq] = auxnombre;

                        auxCarnet = carnet[pos];
                        carnet[pos] = carnet[izq];
                        carnet[izq] = auxCarnet;

                        auxTelefono = telefono[pos];
                        telefono[pos] = telefono[izq];
                        telefono[izq] = auxTelefono;

                        auxtotal = pago[pos];
                        pago[pos] = pago[izq];
                        pago[izq] = auxtotal;

                        auxCarrera = carrera[pos];
                        carrera[pos] = carrera[izq];
                        carrera[izq] = auxCarrera;


                        pos = izq;

                    }
                }
            }

            if ((pos - 1) > ini)
            {
                reduceRecursivo(ini, pos - 1);
            }
            if (fin > (pos + 1))
            {
                reduceRecursivo(pos + 1, fin);
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
