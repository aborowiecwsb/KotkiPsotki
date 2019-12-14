using System;
using System.Net;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;



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
                List<int> stats = new List<int>();

                //var statistics = new Dictionary<string, string> { };
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
                    if (File.Exists(path) == true)
                    {
                        string text = File.ReadAllText(path, Encoding.UTF8);
                        int count = text.Count(char.IsLetter);
                        Console.WriteLine("Ilość liter występująca w tekście: " + count);
                        stats.Add(count);
                        Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                        Console.ReadLine();

                    }
                    else
                    {
                        Console.WriteLine("Plik nie istnieje.");

                    }
                }

                //Opcja liczenia ilości wyrazów w pobranym pliku

                if (menuOption == 3)
                {

                    string words = Path.Combine(Environment.CurrentDirectory, "X.txt.");

                    if (File.Exists(words) == true)
                    {
                        char[] separators = { ' ', ',', '.', ':', ';', '?', '!', '-', '=', '+', '-', '*', '/' };


                        int wordsCount = words.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
                        stats.Add(wordsCount);
                        Console.WriteLine("Liczba wyrazów występujących w tekście: " + wordsCount);
                        Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Plik nie istnieje.");

                    }
                }

                //Opcja liczenia ilości znaków interpunkcyjnych w pobranym pliku

                if (menuOption == 4)
                {

                    string punctuation = Path.Combine(Environment.CurrentDirectory, "X.txt.");

                    if (File.Exists(punctuation) == true)
                    {
                        string text = File.ReadAllText(punctuation, Encoding.UTF8);
                        int punctuationCount = text.Count(predicate: char.IsPunctuation);
                        stats.Add(punctuationCount);
                        Console.WriteLine("Liczba znaków interpunkcyjnych występujących w tekście: " + punctuationCount);
                        Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Plik nie istnieje.");

                    }
                }

                //Opcja liczenia ilości zdań w pobranym pliku

                if (menuOption == 5)
                {

                    string sentence = Path.Combine(Environment.CurrentDirectory, "X.txt.");

                    if (File.Exists(sentence) == true)
                    {

                        var sentenceCount = sentence.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
                        var count = sentence.Length;
                        stats.Add(count);

                        Console.WriteLine("Liczba zdań występujących w tekście: " + count.ToString());
                        Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Plik nie istnieje.");

                    }

                }

                //Generacja raportu o występowaniu każdej z liter

                if (menuOption == 6)
                {
                    string path = Path.Combine(Environment.CurrentDirectory, "X.txt");

                    Console.WriteLine("Generacja raportu o występowaniu liter.");

                    if (File.Exists(path) == true)
                    {
                        string text = File.ReadAllText(path, Encoding.UTF8).ToString();

                        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
                        int alphabetLength = alphabet.Length - 1;
                        int i = 0;

                        while (i <= alphabetLength)
                        {
                            int letterCount = 0;
                            foreach (char c in text)
                            {
                                if (c == alphabet[i])
                                {
                                    letterCount++;
                                }
                            }
                            Console.WriteLine("W tekście litera " + alphabet[i] + " występuje " + letterCount + " razy.");
                            i++;
                        }

                        Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Plik nie istnieje.");

                    }
                }

                if (menuOption == 7)
                {
                    string pathStat = Path.Combine(Environment.CurrentDirectory, "statystyki.txt");
                    Console.WriteLine("Tworzenie pliku statystyki.txt");

                    using (FileStream fs = File.Create(pathStat))
                    {
                    }
                }
            }
        }

    }
}
