using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class SeleccionDirecta
    {
       
            public int cantidad, i = 0;

            public int[] carnet;
            public string[] nombre;
            public int[] telefono;
            public string[] carrera;
            public double[] pago;

            public SeleccionDirecta(int cantidad)
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

            public void Selec()
            {
                string auxnombre;
                double auxtotal;
                int auxCarnet;
                int auxTelefono;
                string auxCarrera;
                for (int i = 0; i < cantidad - 1; i++)
                {
                    int Min = i;
                    for (int j = 0; j < cantidad; j++)
                    {
                        if (carnet[j].CompareTo(carnet[i]) <= 0)
                        {
                            Min = j;
                        }
                    }
                    if (i != Min)
                    {
                        auxCarnet = carnet[i];
                        carnet[i] = carnet[Min];
                        carnet[Min] = auxCarnet;

                        auxnombre = nombre[i];
                        nombre[i] = nombre[Min];
                        nombre[Min] = auxnombre;

                        auxTelefono = telefono[i];
                        telefono[i] = telefono[Min];
                        telefono[Min] = auxTelefono;

                        auxCarrera = carrera[i];
                        carrera[i] = carrera[Min];
                        carrera[Min] = auxCarrera;

                        auxtotal = pago[i];
                        pago[i] = pago[Min];
                        pago[Min] = auxtotal;
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
