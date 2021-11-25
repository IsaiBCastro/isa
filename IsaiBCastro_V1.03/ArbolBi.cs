using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

namespace IsaiBCastro_V1._03
{
    class ArbolBi
    {
        public Nodo raiz;

        Graphics nodo;
        Font font;

        int coordenadasX = 740;
        int coordenadasY = 45;

        bool encontrado = false;

        public ArbolBi()
        {
            raiz = null;
        }
        public ArbolBi(Graphics nodo, Font font)
        {
            this.nodo = nodo;
            this.font = font;
        }

        public bool InsertarDatos(double total)
        {
            Nodo temp = new Nodo();

            temp.total = total;
            temp.izquierdo = null;
            temp.derecho = null;

            if (raiz == null)
            {
                raiz = temp;
                temp.nivel = 1;
                return true;
            }
            else
            {
                Nodo anterior = null, ant;
                ant = raiz;

                while (ant != null)
                {
                    anterior = ant;
                    if (total < ant.total)
                    {
                        ant = ant.izquierdo;
                    }
                    else
                    {
                        ant = ant.derecho;
                    }
                }
                if (total < anterior.total)
                {
                    temp.nivel++;
                    anterior.izquierdo = temp;
                    return true;
                }
                else if (total > anterior.total)
                {
                    temp.nivel++;
                    anterior.derecho = temp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MostrarArbol(PaintEventArgs e, Color c)
        {
            e.Graphics.Clear(c);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            nodo = e.Graphics;
            DibujarArbol(nodo, font, Brushes.White, Brushes.Black, Pens.White, Brushes.Black);
        }

        public bool Eliminar(double total)
        {
            raiz = EliminarNodo(raiz, total);
            return encontrado;
        }

        public Nodo EliminarNodo(Nodo Raiz, double total)
        {
            if (Raiz == null)
            {
                MessageBox.Show("No se ha encontrado el nodo a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                encontrado = false;
            }
            else if (total < Raiz.total)
            {
                Nodo izq = EliminarNodo(Raiz.izquierdo, total);
                Raiz.izquierdo = izq;
            }
            else if (total > Raiz.total)
            {
                Nodo der = EliminarNodo(Raiz.derecho, total);
                Raiz.derecho = der;
            }
            else
            {
                Nodo axu = Raiz;

                if (axu.derecho == null)
                {
                    Raiz = axu.izquierdo;
                }
                else if (axu.izquierdo == null)
                {
                    Raiz = axu.derecho;
                }
                else
                {
                    axu = Cambiar(axu);
                }
                axu = null;
                encontrado = true;
            }
            return Raiz;
        }
        protected Nodo Cambiar(Nodo axu)
        {
            Nodo temp = axu;
            Nodo temp2 = axu.izquierdo;

            while (temp2.derecho != null)
            {
                temp = temp2;
                temp2 = temp2.derecho;
            }
            axu.total = temp2.total;

            if (temp == axu)
            {
                temp.izquierdo = temp2.izquierdo;
            }
            else
            {
                temp.derecho = temp2.izquierdo;
            }
            return temp2;
        }
        public void DibujarArbol(Graphics grafico, Font fuente, Brush colorRelleno, Brush colorFuente, Pen relacion, Brush borde)
        {
            if (raiz == null)
            {
                return;
            }

            raiz.UbicacionNodo(coordenadasX, coordenadasY);
            raiz.DibujarRamas(grafico, relacion);
            raiz.DibujarNodo(grafico, fuente, colorRelleno, colorFuente, relacion, borde);

        }
        public void InOrden(ListBox lst, Label lbl)
        {
            lst.Items.Clear();
            InOrden(raiz, lst, lbl);
        }
        public void InOrden(Nodo temp, ListBox lst, Label lbl)
        {
            if (temp != null)
            {
                lbl.Text = "Recorrido InOrden";
                InOrden(temp.izquierdo, lst, lbl);
                lst.Items.Add(temp.total.ToString());
                InOrden(temp.derecho, lst, lbl);
            }
        }

        public void PosOrden(ListBox lst, Label lbl)
        {
            lst.Items.Clear();
            PosOrden(raiz, lst, lbl);
        }
        public void PosOrden(Nodo temp, ListBox lst, Label lbl)
        {
            if (temp != null)
            {
                lbl.Text = "Recorrido PosOrden";
                PosOrden(temp.izquierdo, lst, lbl);
                PosOrden(temp.derecho, lst, lbl);
                lst.Items.Add(temp.total.ToString());
            }
        }

        public void PreOrden(ListBox lst, Label lbl)
        {
            lst.Items.Clear();
            PreOrden(raiz, lst, lbl);
        }
        public void PreOrden(Nodo temp, ListBox lst, Label lbl)
        {
            if (temp != null)
            {
                lbl.Text = "Recorrido PreOrden";
                lst.Items.Add(temp.total.ToString());
                PreOrden(temp.izquierdo, lst, lbl);
                PreOrden(temp.derecho, lst, lbl);
            }
        }
    }
}
