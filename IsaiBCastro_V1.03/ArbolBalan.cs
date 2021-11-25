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
    class ArbolBalan
    {

        #region Variables a usar
        public Nodo raiz;

        Graphics nodo;
        Font font;

        int coordenadasX = 740;
        int coordenadasY = 45;
        bool duplicado = false;

        bool existe = false;
        #endregion

        #region Sobrecarga de constructores
        public ArbolBalan()
        {

        }
        public ArbolBalan(Nodo nueva)
        {
            raiz = nueva;
        }
        public ArbolBalan(Graphics nodo, Font font)
        {
            this.nodo = nodo;
            this.font = font;
        }
        #endregion

        #region Equilibrar
        private int FactorEquilibrio(Nodo x)
        {
            if (x == null)
            {
                return -1;
            }
            else
            {
                return x.fe;
            }
        }
        #endregion

        #region Rotaciones
        private Nodo RotacionIzquierda(Nodo x)
        {
            Nodo auxiliar = x.izquierdo;
            x.izquierdo = auxiliar.derecho;
            auxiliar.derecho = x;
            x.fe = Math.Max(FactorEquilibrio(x.izquierdo), FactorEquilibrio(x.derecho)) + 1;
            auxiliar.fe = Math.Max(FactorEquilibrio(auxiliar.izquierdo), FactorEquilibrio(auxiliar.derecho)) + 1;
            return auxiliar;
        }
        private Nodo RotacionDerecha(Nodo x)
        {
            Nodo auxiliar = x.derecho;
            x.derecho = auxiliar.izquierdo;
            auxiliar.izquierdo = x;
            x.fe = Math.Max(FactorEquilibrio(x.izquierdo), FactorEquilibrio(x.derecho)) + 1;
            auxiliar.fe = Math.Max(FactorEquilibrio(auxiliar.izquierdo), FactorEquilibrio(auxiliar.derecho)) + 1;
            return auxiliar;
        }

        private Nodo DerechaDerecha(Nodo x)
        {
            Nodo temp;
            x.derecho = RotacionIzquierda(x.derecho);
            temp = RotacionDerecha(x);
            return temp;
        }

        private Nodo IzquierdaIzquierda(Nodo x)
        {
            Nodo temp;
            x.izquierdo = RotacionDerecha(x.izquierdo);
            temp = RotacionIzquierda(x);
            return temp;
        }
        #endregion

        #region Insertar Nodo
        private Nodo Insertar(Nodo nuevo, Nodo subArb)
        {
            Nodo nuevoPadre = subArb;

            if (nuevo.total < subArb.total)
            {
                if (subArb.izquierdo == null)
                {
                    subArb.izquierdo = nuevo;
                }
                else
                {
                    subArb.izquierdo = Insertar(nuevo, subArb.izquierdo);
                    if (FactorEquilibrio(subArb.izquierdo) - FactorEquilibrio(subArb.derecho) == 2)
                    {
                        if (nuevo.total < subArb.izquierdo.total)
                        {
                            nuevoPadre = RotacionIzquierda(subArb);
                        }
                        else
                        {
                            nuevoPadre = IzquierdaIzquierda(subArb);
                        }
                    }
                }

                duplicado = false;
            }
            else if (nuevo.total > subArb.total)
            {
                if (subArb.derecho == null)
                {
                    subArb.derecho = nuevo;
                }
                else
                {
                    subArb.derecho = Insertar(nuevo, subArb.derecho);
                    if (FactorEquilibrio(subArb.derecho) - FactorEquilibrio(subArb.izquierdo) == 2)
                    {
                        if (nuevo.total > subArb.derecho.total)
                        {
                            nuevoPadre = RotacionDerecha(subArb);
                        }
                        else
                        {
                            nuevoPadre = DerechaDerecha(subArb);
                        }
                    }
                }
                duplicado = true;
            }
            else
            {
                duplicado = true;
            }

            if ((subArb.izquierdo == null) && (subArb.derecho != null))
            {
                subArb.fe = subArb.derecho.fe + 1;
            }
            else if ((subArb.derecho == null) && (subArb.izquierdo != null))
            {
                subArb.fe = subArb.izquierdo.fe + 1;
            }
            else
            {
                subArb.fe = Math.Max(FactorEquilibrio(subArb.izquierdo), FactorEquilibrio(subArb.derecho)) + 1;
            }
            return nuevoPadre;
        }
        #endregion

        #region Insertar
        public bool InsertarDatos(double total)
        {
            Nodo nuevo = new Nodo(total);

            if (raiz == null)
            {
                raiz = nuevo;
            }
            if (raiz != null)
            {
                raiz = Insertar(nuevo, raiz);
            }

            return duplicado;
        }
        #endregion

        #region Eliminar
        public bool Eliminar(double total)
        {
            raiz = EliminarNodo(raiz, total);
            return existe;
        }
        #endregion

        #region Eliminar Nodo
        private Nodo EliminarNodo(Nodo Raiz, double total)
        {
            if (Raiz == null)
            {
                existe = false;
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
                existe = true;
            }
            return Raiz;
        }
        #endregion

        #region Cambiar
        private Nodo Cambiar(Nodo axu)
        {
            Nodo temp = axu, temp2 = axu.izquierdo;

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
        #endregion

        #region Metodo para dibujar el arbol cada vez que haya cambio 
        public void MostrarArbol(PaintEventArgs e, Color c)
        {
            e.Graphics.Clear(c);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            nodo = e.Graphics;
            DibujarArbol(nodo, font, Brushes.White, Brushes.Black, Pens.White, Brushes.Black);
        }
        #endregion

        #region Dibujar el arbol
        private void DibujarArbol(Graphics grafico, Font fuente, Brush colorRelleno, Brush colorFuente, Pen relacion, Brush borde)
        {
            if (raiz == null)
            {
                return;
            }

            raiz.UbicacionNodo(coordenadasX, coordenadasY);
            raiz.DibujarRamas(grafico, relacion);
            raiz.DibujarNodo(grafico, fuente, colorRelleno, colorFuente, relacion, borde);

        }
        #endregion

        #region Recorrido InOrden
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
        #endregion

        #region Recorrido PosOrden
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
        #endregion

        #region Recorrido PreOrden
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
        #endregion
    }
}
