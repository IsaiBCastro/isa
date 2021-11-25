using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class Hash
    {
        public int i, cantidad;
        public int[] carnet;
        public string[] nombre;
        public int[] telefono;
        public string[] carrera;
        public double[] pago;
        public Hash(int n)
        {
            this.cantidad = cantidad;
            nombre = new string[cantidad];
            carnet = new int[cantidad];
            telefono = new int[cantidad];
            pago = new double[cantidad];
            carrera = new string[cantidad];
        }
        public void entra(int Carnet, string Nombre, int Telefono, string Carrera, double Pago)
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
        public int H(int k)
        {
            int tamaño = cantidad - 1;
            int au = 0;
            au = (k % tamaño);
            return au;
        }
        public void PruebaLineal(int k)
        {
            int X = 0;
            int res = H(k);
            if (X != -1 && res == k)
            {
                MessageBox.Show(string.Format("\n Informacion:\n \n- Carnet:{0} \n- Nombre: {1} \n- Telefono: {2} \n- Carrera: {3} \n- Pago Matricula: {4}",
                         carnet[res], nombre[res], telefono[res], carrera[res], pago[res]), "Busqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                X = res + 1;
                while (X <= cantidad - 1 && pago[X] != -1 && pago[X] != k && X != res)
                {
                    X = X + 1;
                    if (X == cantidad)
                    {
                        X = 0;
                    }
                }
                try
                {
                    if (pago[X] == -1 || (X == res))
                    {
                        MessageBox.Show("el elemento no se encuentra");
                    }
                    else
                    {
                        MessageBox.Show("el elemento esta en la posicion " + (X + 1));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("el elemento esta en la posicion " + (X));
                }
            }
        }
    }
}
