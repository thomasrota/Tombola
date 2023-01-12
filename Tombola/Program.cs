using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;                          // Nascondi cursore

            // Dichiarazioni
            int[,] cartella1 = new int[3, 5];                       // Variabile tipo matrice cartella 1
            int[,] cartella2 = new int[3, 5];                       // Variabile tipo matrice cartella 2
            int righe = 3, colonne = 5;                             // Assegnazione alle variabili 'righe' e 'colonne'
            int cx1 = 2, cy1 = 22, cx2 = 22, cy2 = 22;              // Assegnazioni variabili per le coordinate delle cartelle

            List<int> nestratti = new List<int>();                  // Creazione una lista di interi chiamata 'nestratti' per memorizzare i numeri estratti

            int[,] tabellone = new int[9, 10];                      // Dichiarazione variabile tipo matrice 'tabellone'
            int numero = 1;                                         // Assegnazione variabile 'numero'
            
            // Elaborazione

            // Ciclo "inserimento" valori nella matrice
            for (int i = 0; i < 9; i++)                             // Ciclo righe tabellone                      
            {
                for (int j = 0; j < 10; j++)                        // Ciclo colonne tabellone
                {
                    tabellone[i, j] = numero;                       // Inserimento agli indici i, j la variabile 'numero'
                    numero++;                                       // Incremento variabile numero
                }
            }

            // Stampa del tabellone
            Console.SetCursorPosition(1, 0);                       // Posizionamento cursore alle coordinate 1, 0
            Console.WriteLine("Tabellone:");                       // Stampa 'Tabellone:'
            for (int i = 0; i < 9; i++)                            // Ciclo righe tabellone
            {
                for (int j = 0; j < 10; j++)                       // Ciclo colonne tabellone
                {
                    int x1 = j + 1;                                // Calcolo posizione della colonna
                    int y1 = i + 1;                                // Calcolo posizione della riga
                    int left = x1 * 4 - 3;                         // Calcolo spazio tra le colonne
                    int top = y1 * 2 - 1;                          // Calcolo spazio tra le righe
                    Console.SetCursorPosition(left, top);          // Posizionamento cursore alle coordinate left, top
                    Console.Write(tabellone[i, j]);                // Stampa variabile matrice 'tabellone'
                }
            }

            // Visualizza il numero estratto a destra del tabellone
            Console.SetCursorPosition(45, 0);                      // Posizionamento cursore alle coordinate 45, 0
            Console.WriteLine("Numero estratto:");                 // Stampa 'Numero estratto:'

            // Chiama la funzione per generare e stampare le cartelle
            GeneraCartelle(cartella1, cartella2, righe, colonne, cx1, cy1, cx2, cy2);

            for (int v = 0; v < 90; v++)                           // Ciclo elaborazione
            {
                Random random = new Random();                      // Dichiarazione variabile 'random'
                int numeroEstratto;                                // Dichiarazione variabile numeroEstratto

                // Generazione numero casuale finché non viene estratto un numero che non è stato ancora estratto
                do                                                 // Esegui...
                {
                    Thread.Sleep(1250);                            // Attesa per estrarre
                    numeroEstratto = random.Next(1, 91);           // Estrazione numero
                } while (nestratti.Contains(numeroEstratto));      // ...mentre 'nestratti' contiene 'numeroEstratto'

                nestratti.Add(numeroEstratto);                     // Inserimento del numero estratto alla lista estratti

                Console.SetCursorPosition(45, 1);                  // Posiziona cursore a 45, 1
                Console.WriteLine(numeroEstratto);                 // Stampa variabile numeroEstratto

                // Chiama la funzione per colorare il numero sul tabellone corrispondente di rosso
                ColoraTabellone(tabellone, numeroEstratto);

                // Chiama la funzione per colorare di verde il numero della cartella 1 corrispondente a quello estratto
                ColoraNumeroEstrattoCartella1(numeroEstratto, cartella1, 2, 22);

                // Chiama la funzione per colorare di verde il numero della cartella 2 corrispondente a quello estratto
                ColoraNumeroEstrattoCartella2(numeroEstratto, cartella2, 22, 22);

                // Chiama la funzione per verificare chi ha vinto
                Vincitore(numeroEstratto);
            }
        }
        
        // Funzione 'ColoraTabellone' che va a modificare il colore del numero del tabellone corrispondente a quello estratto
        static void ColoraTabellone(int[,] tabellone, int numeroEstratto)
        {
            // Cambia il colore del numero estratto nel tabellone
            Console.ForegroundColor = ConsoleColor.Red;                     // Impostazione del colore del carattere a rosso

            // Ciclo controllo elementi tabellone
            for (int i = 0; i < 9; i++)                                     // Ciclo righe tabellone
            {
                for (int j = 0; j < 10; j++)                                // Ciclo colonne tabellone
                {
                    if (tabellone[i, j] == numeroEstratto)                  // Condizione che verifica se il numero presente nella matrice a i, j è uguale al numero estratto
                    {
                        int x = j + 1;                                      // Posizione della colonna
                        int y = i + 1;                                      // Posizione della riga
                        int left = x * 4 - 3;                               // Spazio tra le colonne
                        int top = y * 2 - 1;                                // Spazio tra le righe
                        Console.SetCursorPosition(left, top);               // Posizionamento cursore alle coordinate left, top
                        Console.Write(numeroEstratto);                      // Stampa variabile 'numeroEstratto'
                    }
                }
            }
            Console.ResetColor();                                           // Impostazione del background e del colore dei caratteri al colore predefinito
        }
        static List<int> cartella1_numbers = new List<int>();               // Lista di elementi contententi variabili di tipo int denominata 'cartella1_numbers'
        static List<int> cartella2_numbers = new List<int>();               // Lista di elementi contententi variabili di tipo int denominata 'cartella2_numbers'
        
        // Funzione 'GeneraCartelle' che va a generare le cartelle della tombola
        static void GeneraCartelle(int[,] cartella1, int[,] cartella2, int righe, int colonne, int cx1, int cy1, int cx2, int cy2)
        {
            Random random = new Random();                                   // Dichiarazione variabile 'random'
            // Stampa cartella 1
            Console.SetCursorPosition(2, 20);                               // Posiziona cursore alle coordinate 2, 20 (sotto il tabellone)
            Console.WriteLine("Cartella 1");                                // Stampa 'Cartella 1'
            for (int i = 0; i < righe; i++)                                 // Ciclo righe cartella 1                         
            {
                Console.SetCursorPosition(cx1, cy1);                        // Posizionamento cursore alle coordinate cx1, cy1
                for (int j = 0; j < colonne; j++)                           // Ciclo colonne cartella 1
                {
                    cartella1[i, j] = random.Next(1, 91);                   // Generazione numeri randomici all'interno della matrice
                    cartella1_numbers.Add(cartella1[i, j]);                 // Aggiunta di 'cartella1' alla lista 'cartella1_numbers'
                    Console.Write(cartella1[i, j] + " ");                   // Stampa il contenuto della riga della cartella
                }
                Console.WriteLine();                                        // A capo
                cy1++;                                                      // Incremento variabile 'cy1'
            }

            // Stampa cartella 2
            Console.SetCursorPosition(22, 20);                              // Posiziona cursore alle coordinate 22, 20 (accanto alla cartella 1)
            Console.WriteLine("Cartella 2");                                // Stampa 'Cartella 2'
            for (int i = 0; i < righe; i++)                                 // Ciclo righe cartella 1
            {
                Console.SetCursorPosition(cx2, cy2);                        // Posizona cursore alle coordinate cx2, cy2
                for (int j = 0; j < colonne; j++)                           // Ciclo colonne cartella 2
                {
                    cartella2[i, j] = random.Next(1, 91);                   // Genera numeri randomici della cartella
                    cartella2_numbers.Add(cartella2[i, j]);                 // Aggiunta di 'cartella2' alla lista 'cartella2_numbers'
                    Console.Write(cartella2[i, j] + " ");                   // Stampa il contenuto della riga della cartella
                }
                Console.WriteLine();                                        // A capo
                cy2++;                                                      // Incremento variabile 'cy2'
            }
        }
        
        // Funzione 'ColoraNumeroEstrattoCartella1' che va a colorare il numero presente nella cartella 1, corrispettivo a quello estratto, di verde
        static void ColoraNumeroEstrattoCartella1(int numeroEstratto, int[,] cartella1, int cx1, int cy1)
        {
            int righe = 3, colonne = 5;                                     // Assegnazione variabili 'righe' e 'colonne'
            for (int i = 0; i < righe; i++)                                 // Ciclo righe cartella 1
            {
                Console.SetCursorPosition(cx1, cy1);                        // Posizionamento cursore alle coordinate cx1, cy1
                for (int j = 0; j < colonne; j++)                           // Ciclo colonne cartella 1
                {
                    if (cartella1[i, j] == numeroEstratto)                  // Condizione verifica che il numero presente nella cartella agli indici i, j sia uguale al numero estratto
                    {
                        Console.ForegroundColor = ConsoleColor.Green;       // Impostazione del colore del colore del carattere a verde
                        Console.Write(numeroEstratto);                      // Stampa variabile 'numeroEstratto'
                    }
                }
                Console.WriteLine();                                        // A capo
                cy1++;                                                      // Incremento variabile 'cy1'
            }
            Console.ResetColor();                                           // Impostazione del background e del colore dei caratteri al colore predefinito
        }

        // Funzione 'ColoraNumeroEstrattoCartella2' che va a colorare il numero presente nella cartella 2, corrispettivo a quello estratto, di verde
        static void ColoraNumeroEstrattoCartella2(int numeroEstratto, int[,] cartella2, int cx2, int cy2)
        {
            int righe = 3, colonne = 5;                                     // Assegnazione variabili 'righe' e 'colonne'
            for (int i = 0; i < righe; i++)                                 // Ciclo righe cartella 2
            {
                Console.SetCursorPosition(cx2, cy2);                        // Posizionamento cursore alle coordinate cx2, cy2
                for (int j = 0; j < colonne; j++)                           // Ciclo colonne cartella 2
                {
                    if (cartella2[i, j] == numeroEstratto)                  // Condizione verifica che il numero presente nella cartella agli indici i, j sia uguale al numero estratto
                    {
                        Console.ForegroundColor = ConsoleColor.Green;       // Impostazione del colore del colore del carattere a verde
                        Console.Write(numeroEstratto);                      // Stampa variabile 'numeroEstratto'
                    }
                }
                Console.WriteLine();                                        // A capo
                cy2++;                                                      // Incremento variabile 'cy2'
            }
            Console.ResetColor();                                           // Impostazione del background e del colore dei caratteri al colore predefinito
        }
        
        // Funzione 'Vincitore' che decreta quali dei due giocatori ha vinto
        static void Vincitore(int numeroEstratto)
        {
            if (cartella1_numbers.Contains(numeroEstratto))                 // Condizione che verifica che nella lista 'cartella1_numbers' siano presente 'numeroEstratto'
            {
                cartella1_numbers.Remove(numeroEstratto);                   // Rimozione dalla lista 'cartella1_numbers' la variabile 'numeroEstratto'
                if (cartella1_numbers.Count == 0)                           // Condizione che verifica se il numero degli elementi presenti in 'cartella1_numbers' sia zero
                {
                    Console.SetCursorPosition(2, 26);                       // Posizionamento cursore alle coordinate 2, 26
                    Console.WriteLine("Giocatore 1 ha vinto!");             // Stampa 'Giocatore 1 ha vinto!'
                    Environment.Exit(1);                                    // Termina programma
                }
            }
            if (cartella2_numbers.Contains(numeroEstratto))                 // Condizione che verifica che nella lista 'cartella2_numbers' siano presente 'numeroEstratto'
            {
                cartella2_numbers.Remove(numeroEstratto);                   // Rimozione dalla lista 'cartella2_numbers' la variabile 'numeroEstratto'
                if (cartella2_numbers.Count == 0)                           // Condizione che verifica se il numero degli elementi presenti in 'cartella2_numbers' sia zero
                {
                    Console.SetCursorPosition(2, 26);                       // Posizionamento cursore alle coordinate 2, 26
                    Console.WriteLine("Giocatore 2 ha vinto!");             // Stampa 'Giocatore 2 ha vinto!'
                    Environment.Exit(1);                                    // Termina programma
                }
            }
        }
    }
}