using System;
using System.Net;
using System.IO;
using System.Text;
using System.Linq;



namespace Wordreader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu główne, działające w nieskończonej pętli
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
                //Opcja wyjścia z aplikacji
                if (menuOption == 8)
                    break;
                //Opcja pobierania pliku
                if (menuOption == 1)
                {
                    Console.WriteLine("Pobieranie pliku.");
                    WebClient DownloadFile = new WebClient();

                    try
                    {
                        DownloadFile.DownloadFile("https://s3.zylowski.net/public/input/1.txt", Path.Combine(Environment.CurrentDirectory, "X.txt"));

                        Console.WriteLine("Plik został pobrany pomyślnie");
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("Błąd pobierania. Sprawdź połączenie z internetem.");
                    }
                }
                //Opcja zliczania liter występujących w pobranym pliku
                if (menuOption == 2)
                {
                    string path = Path.Combine(Environment.CurrentDirectory, "X.txt");
                    Console.WriteLine("Liczenie liter występujących w pliku tekstowym.");

                    string text = File.ReadAllText(path, Encoding.UTF8);
                    int count = text.Count(char.IsLetter);
                    Console.WriteLine("Ilość liter występująca w tekście: " + count);
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                }
            }
        }
    }
}
