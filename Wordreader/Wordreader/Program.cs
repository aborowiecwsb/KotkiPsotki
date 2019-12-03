using System;
using System.Net;
using System.IO;



namespace Wordreader
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter(A - Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2 - 5 do pliku statystyki.txt.");
                Console.WriteLine("8. Wyjście z programu.");
                int menuOption = Convert.ToInt32(Console.ReadLine());
                if (menuOption == 8)
                    break;
                if (menuOption == 1)
                {
                    Console.WriteLine("Pobieranie pliku.");
                    WebClient DownloadFile = new WebClient();

                    try
                    {
                        DownloadFile.DownloadFile("https://s3.zylowski.net/public/input/X.txt", Path.Combine(Environment.CurrentDirectory, "X.txt"));

                        Console.WriteLine("Plik został pobrany pomyślnie");
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("Błąd pobierania. Sprawdź połączenie z internetem.");
                    }
                }
            }
        }
    }
}
