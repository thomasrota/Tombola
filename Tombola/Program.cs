using System;
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
            Random r = new Random();
            int[,] cartella1 = new int[3, 5]; // Variabile tipo matrice cartella 1
            int[,] cartella2 = new int[3, 5]; // Variabile tipo matrice cartella 2
            int righe = 3, colonne = 5;
            int cx1 = 2, cy1 = 22, cx2 = 22, cy2 = 22; // Variabili per le coordinate delle cartelle


            // Crea una lista per memorizzare i numeri estratti
            List<int> nestratti = new List<int>();

            // Dichiarazione matrice
            int[,] tabellone = new int[9, 10];
            int numero = 1;
            for (int i = 0; i < 9; i++) // "Inserimento" valori nella matrice
            {
                for (int j = 0; j < 10; j++)
                {
                    tabellone[i, j] = numero;
                    numero++;
                }
            }

            // Stampa del tabellone
            Console.SetCursorPosition(1,0);
            Console.WriteLine("Tabellone:");
            Console.WriteLine("");
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

            // Genera un numero casuale finché non viene estratto un numero che non è stato ancora estratto
            Random random = new Random();
            int numeroEstratto;
            do
            {
                numeroEstratto = random.Next(1, 91);
            } while (nestratti.Contains(numeroEstratto));

            // Aggiungi il numero estratto alla lista estratti
            nestratti.Add(numeroEstratto);

            // Visualizza il numero estratto a destra del tabellone
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("Numero estratto:");
            Console.SetCursorPosition(45, 1);
            Console.WriteLine(numeroEstratto);

            // Chiama la funzione per estrarre e visualizzare il numero e colorare il numero sul tabellone corrispondente di rosso
            EstraiNumero(tabellone, numeroEstratto);

            // Chiama la funzione per generare e stampare le cartelle
            GeneraCartelle(cartella1, cartella2, righe, colonne, cx1, cy1, cx2, cy2);

            // Chiama la funzione per colorare di verde il numero della cartella 1 corrispondente a quello estratto
            ColoraNumeroEstrattoCartella1(numeroEstratto, cartella1, 2, 22);

            // Chiama la funzione per colorare di verde il numero della cartella 2 corrispondente a quello estratto
            ColoraNumeroEstrattoCartella2(numeroEstratto, cartella2, 22, 22);

        }

        static void EstraiNumero(int[,] tabellone, int numeroEstratto)
        {
            // Cambia il colore del numero estratto nel tabellone
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tabellone[i, j] == numeroEstratto)
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
            Console.ResetColor();
        }
        static void GeneraCartelle(int[,] cartella1, int[,] cartella2, int righe, int colonne, int cx1, int cy1, int cx2, int cy2)
        {
            Random random = new Random();
            // Stampa cartella 1
            Console.SetCursorPosition(2, 20); // Posiziona cartella 1 sotto il tabellone
            Console.WriteLine("Cartella 1");
            for (int i = 0; i < righe; i++)
            {
                Console.SetCursorPosition(cx1, cy1);
                for (int j = 0; j < colonne; j++)
                {
                    cartella1[i, j] = random.Next(1, 91); // Genera numeri randomici della cartella
                    Console.Write(cartella1[i, j] + " "); // Stampa il contenuto della riga della cartella
                }
                Console.WriteLine();
                cy1++;
            }

            // Stampa cartella 2
            Console.SetCursorPosition(22, 20); // Posiziona cartella 2 accanto alla cartella 1
            Console.WriteLine("Cartella 2");
            for (int i = 0; i < righe; i++)
            {
                Console.SetCursorPosition(cx2, cy2); // Posizona i numeri contenuti nelle cartelle
                for (int j = 0; j < colonne; j++)
                {
                    cartella2[i, j] = random.Next(1, 91); // Genera numeri randomici della cartella
                    Console.Write(cartella2[i, j] + " "); // Stampa il contenuto della riga della cartella
                }
                Console.WriteLine();
                cy2++;
            }
        }
        static void ColoraNumeroEstrattoCartella1(int numeroEstratto, int[,] cartella1, int cx1, int cy1)
        {
            int righe = 3, colonne = 5;
            for (int i = 0; i < righe; i++)
            {
                Console.SetCursorPosition(cx1, cy1);
                for (int j = 0; j < colonne; j++)
                {
                    if (cartella1[i, j] == numeroEstratto)
                    { 
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(numeroEstratto);
                        
                    }
                }
                Console.WriteLine();
                cy1++;
            }
            Console.ResetColor();
        }
        static void ColoraNumeroEstrattoCartella2(int numeroEstratto, int[,] cartella2, int cx2, int cy2)
        {
            int righe = 3, colonne = 5;
            for (int i = 0; i < righe; i++)
            {
                Console.SetCursorPosition(cx2, cy2);
                for (int j = 0; j < colonne; j++)
                {
                    if (cartella2[i, j] == numeroEstratto)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(numeroEstratto);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                cy2++;
            }
        }
    }
}