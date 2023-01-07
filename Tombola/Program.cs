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
            List<int> estratti = new List<int>();

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
            EstraiNumero(estratti);
        }
        static void EstraiNumero(List<int> estratti)
        {
            // Genera un numero casuale finché non viene estratto un numero che non è stato ancora estratto
            Random random = new Random();
            int numeroEstratto;
            do
            {
                numeroEstratto = random.Next(1, 91);
            } while (estratti.Contains(numeroEstratto));

            // Aggiungi il numero estratto alla lista estratti
            estratti.Add(numeroEstratto);

            // Visualizza il numero estratto a destra del tabellone
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("Numero estratto:");
            Console.SetCursorPosition(45, 1);
            Console.WriteLine(numeroEstratto);
        }
    }
}