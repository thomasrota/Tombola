﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dichiarazione matrice
            int[,] tabellone = new int[9, 10];
            int numero = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tabellone[i, j] = numero;
                    numero++;
                }
            }

            // Stampa del tabellone
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int x = j + 1;  // Posizione della colonna
                    int y = i + 1;  // Posizione della riga
                    int left = x * 4 - 3;  // Spazio tra le colonne
                    int top = y * 2 - 1;  // Spazio tra le righe
                    Console.SetCursorPosition(left, top);
                    Console.Write(tabellone[i, j]);
                }
            }
        }
    }
}