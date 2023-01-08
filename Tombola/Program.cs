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

            // Chiama la funzione per estrarre e visualizzare il numero
            EstraiNumero(nestratti, tabellone);

            // Chiama la funzione per generare e stampare le cartelle
            GeneraCartelle();
        }
        static void EstraiNumero(List<int> nestratti, int[,] tabellone)
        {
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
            Console.ResetColor(); // Resetta il colore
        }
        static void GeneraCartelle()
        {
            Random random = new Random();
            int[,] cartella = new int[3, 5]; // Variabile tipo matrice cartella 1
            int[,] cartella2 = new int[3, 5]; // Variabile tipo matrice cartella 2
            int righe = 3, colonne = 5;
            int x = 2, y = 22, x2 = 22, y2 = 22; // Variabili per le coordinate delle cartelle

            // Stampa cartella 1
            Console.SetCursorPosition(2, 20); // Posiziona cartella 1 sotto il tabellone
            Console.WriteLine("Cartella 1");
            for (int i = 0; i < righe; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < colonne; j++)
                {
                    cartella[i, j] = random.Next(1, 91); // Genera numeri randomici della cartella
                    Console.Write(cartella[i, j] + " "); // Stampa il contenuto della riga della cartella
                }
                Console.WriteLine();
                y++;
            }

            // Stampa cartella 2
            Console.SetCursorPosition(22, 20); // Posiziona cartella 2 accanto alla cartella 1
            Console.WriteLine("Cartella 2");
            for (int i = 0; i < righe; i++)
            {
                Console.SetCursorPosition(x2, y2); // Posizona i numeri contenuti nelle cartelle
                for (int j = 0; j < colonne; j++)
                {
                    cartella2[i, j] = random.Next(1, 91); // Genera numeri randomici della cartella
                    Console.Write(cartella2[i, j] + " "); // Stampa il contenuto della riga della cartella
                }
                Console.WriteLine();
                y2++;
            }
        }
    }
}