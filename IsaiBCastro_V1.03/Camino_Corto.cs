using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaiBCastro_V1._03
{
    class Camino_Corto
    {
        public string Algoritmo_floyd(long[,] AMY ,int numero)
        {
            int Vertices = numero;
            long[,] Matriz_Abyasencia = AMY;
            string[,] Caminos = new string[Vertices, Vertices];
            string[,] Caminos_Auxiliares = new string[Vertices, Vertices];
            string CAmino_Recorrido = "", Cadena = "", Caminitos = "";
            int I, J, K;
            float Temporal1, Temporal2, Temporal3, temporal4, Minimo;
            //

            for ( I = 0; I < Vertices; I++)
            {
                for ( J = 0; J < Vertices; J++)
                {
                    Caminos[I, J] = "";
                    Caminos_Auxiliares[I, J] = "";
                }
            }

            for ( K = 0; K < Vertices; K++)
            {
                for ( I = 0; I < Vertices; I++)
                {
                    for ( J = 0; J < Vertices; J++)
                    {
                        Temporal1 = Matriz_Abyasencia[I, J];
                        Temporal2 = Matriz_Abyasencia[I, K];
                        Temporal3 = Matriz_Abyasencia[K, J];
                        temporal4 = Temporal2 + Temporal3;
                        //
                        Minimo = Math.Min(Temporal1, temporal4);

                        if (Temporal1!=temporal4)
                        {
                            if (Minimo==temporal4)
                            {
                                CAmino_Recorrido = "";
                                Caminos_Auxiliares[I, J] = K + "";
                                Caminos[I, J] = Camino_R(I, K, Caminos_Auxiliares, CAmino_Recorrido) + (K + 1);
                            }
                        }
                        Matriz_Abyasencia[I, J] = (long)Minimo;
                    }
                }
            }
            //

            for ( I = 0; I < Vertices; I++)
            {
                for ( J = 0; J < Vertices; J++)
                {
                    Cadena = Cadena + "[" + Matriz_Abyasencia[I, J] + "]";
                }
                Cadena = Cadena + "\n";
            }
            ////////

            for ( I = 0; I < Vertices; I++)
            {
                for ( J = 0; J < Vertices; J++)
                {
                    if (Matriz_Abyasencia[I,J]!=1000000000)
                    {
                        if (I != J)
                        {
                            if (Caminos[I,J].Equals(""))
                            {
                                Caminitos += "DE (" + (I + 1) + "------" + (J + 1) + ") " + "irse por( " + (I + 1) + ",   " + (J + 1) + ")\n";
                            }
                            else
                            {
                                Caminitos += "DE (" + (I + 1) + "------" + (J + 1) + ") " + "irse por( " + (I +1 ) + ",   " +Caminos[I,J]+","+ (J + 1) + ")\n";
                            }
                        }
                    }
                }
            }

            return "La Matriz de caminos mas corto entre los diferentes verticces es : \n" + Cadena + "\nLos diferentes caminos mas cortos entre vertices son:\n" + Caminitos;


        }

        public string Camino_R(int I,int K,string[,]Caminos_Auxiliares,string Camino_Recorrido)
        {
            if (Caminos_Auxiliares[I,K].Equals(""))
            {
                return "";
            }
            else
            {
                //Recursividad al millon
                Camino_Recorrido += Camino_R(I, int.Parse(Caminos_Auxiliares[I, K]), Caminos_Auxiliares, Camino_Recorrido) + (int.Parse(Caminos_Auxiliares[I, K]) + 1) + ",   ";
                return Camino_Recorrido;
            }
        }

    }
}
