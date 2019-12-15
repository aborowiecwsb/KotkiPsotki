using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;



namespace Wordreader
{
    class Program
    {
        static void Main(string[] args)
        {
            var standardOutput = Console.Out;

            // case 1
            void downloadFileOption()
            {
                Console.WriteLine("Pobieranie pliku.");
                WebClient DownloadFile = new WebClient();

                try
                {
                    DownloadFile.DownloadFile("https://s3.zylowski.net/public/input/1.txt", Path.Combine(Environment.CurrentDirectory, "X.txt"));

                    Console.WriteLine("Plik został pobrany pomyślnie");
                }
                catch (WebException)
                {
                    Console.WriteLine("Błąd pobierania. Sprawdź połączenie z internetem.");
                }
            }

            // case 2

            int letterCounter()
            {
                string path = Path.Combine(Environment.CurrentDirectory, "X.txt");
                Console.WriteLine("Liczenie liter występujących w pliku tekstowym.");
                if (File.Exists(path) == true)
                {
                    string text = File.ReadAllText(path, Encoding.UTF8);
                    int count = text.Count(char.IsLetter);
                    Console.WriteLine("Ilość liter występująca w tekście: " + count);
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                    return count;
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                    return 0;
                }
            }
            // case 3
            int wordsCounter()
            {
                string words = Path.Combine(Environment.CurrentDirectory, "X.txt.");

                if (File.Exists(words) == true)
                {
                    var readFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "X.txt."));
                    var wordCount = readFile.Split(new char[] { ' ', ',', '.', ':', ';', '?', '!', '-', '=', '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine("Liczba wyrazów występujących w tekście: " + wordCount.Length);
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                    return wordCount.Length;
                }
                {
                    Console.WriteLine("Plik nie istnieje.");
                    return 0;
                }
            }
            //case 4
            int punctuationsCounter()
            {
                string punctuation = Path.Combine(Environment.CurrentDirectory, "X.txt.");
                if (File.Exists(punctuation) == true)
                {
                    
                
                    string text = File.ReadAllText(punctuation, Encoding.UTF8);
                    int liczbaKropek = 0;
                    int liczbaZnakowZapytania = 0;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == '.')
                        {
                            liczbaKropek++;
                        }
                    }
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == '?')
                        {
                            liczbaZnakowZapytania++;
                        }
                    }
                    Console.WriteLine($"Ilosc kropek i znakow zapytania: {liczbaKropek + liczbaZnakowZapytania}");
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                    int znakiRazem = liczbaKropek + liczbaZnakowZapytania;
                    return znakiRazem;
                    
                    
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                    return 0;
                }
            }
            //case 5
            int sentecesCounter()
            {
                string sentence = Path.Combine(Environment.CurrentDirectory, "X.txt.");
                if (File.Exists(sentence) == true)
                {

                    var sentenceCount = sentence.Split(new char[] { ',', '.', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var count = sentence.Length;
                    Console.WriteLine("Liczba zdań występujących w tekście: " + count.ToString());
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                    return count;
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                    return 0;

                }
            }
            //case 6
            void raportGenerate()
            {
                string path = Path.Combine(Environment.CurrentDirectory, "X.txt");

                Console.WriteLine("Generacja raportu o występowaniu samoglosek i spolglosek.");

                if (File.Exists(path) == true)
                {
                    string text = File.ReadAllText(path, Encoding.UTF8).ToString();

                    //char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
                    char[] samogloski = "AEIOUYaeiouy".ToCharArray();
                    char[] spolgloski = "BCDFGHJKLMNPRSTWZbcdfghjklmnprstwz".ToCharArray();
                    int alphabetLength = samogloski.Length - 1;
                    int alphabetLength2 = spolgloski.Length - 1;
                    int i = 0;
                    int j = 0;
                    while (i <= alphabetLength)
                    {
                        int letterCount = 0;
                        foreach (char c in text)
                        {
                            if (c == samogloski[i])
                            {
                                letterCount++;
                            }
                        }
                        Console.WriteLine("W tekście spolgoska: " + samogloski[i] + " wystepuje: " + letterCount + " razy.");
                        i++;
                    }
                    while (j <= alphabetLength2)
                    {
                        int letterCount2 = 0;
                        foreach (char c in text)
                        {
                            if (c == spolgloski[j])
                            {
                                letterCount2++;
                            }
                        }
                        Console.WriteLine("W tekście samogloska: " + spolgloski[j] + " wystepuje: " + letterCount2 + " razy.");
                        j++;
                    }
                    Console.WriteLine("Wprowadź dowolny klawisz, aby kontynuować.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                }
            }

            //case8
            void deleteAll()
            {
                string fileInFolder = Path.Combine(Environment.CurrentDirectory, "X.txt");
                string statistic = Path.Combine(Environment.CurrentDirectory, "statystyki.txt");
                System.IO.File.Delete(fileInFolder);
                System.IO.File.Delete(statistic);

            }
            //case 7
            void saveAllData(int letterCount, int wordsCount, int sentecesCount, int znakiRazem)
            {
                var filestream = new FileStream("statystyki.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(filestream);
                sw.WriteLine("Liczba liter: " + letterCount.ToString());
                sw.WriteLine("Liczba slow: " + wordsCount.ToString());
                sw.WriteLine("Liczba kropek: " + znakiRazem.ToString());
                sw.WriteLine("Liczba zdan: " + sentecesCount.ToString());
                sw.Close();
                Console.WriteLine("Stworzono plik statystyki.txt. Wprowadź dowolny klawisz, aby kontynuować.");
                Console.ReadLine();
            }

            int continueProgram = 1;
            int saveLetterCount = new int();
            int saveWordsCount = new int();
            int saveSentecesCount = new int();
            int saveznakiRazem = new int();

            while (continueProgram == 1)
            {

                Console.WriteLine("1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");
                Console.WriteLine("4. Zlicz liczbę znaków zapytania i kropek.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter(A - Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2 - 5 do pliku statystyki.txt.");
                Console.WriteLine("8. Wyjście z programu.");
                int menuOption = Convert.ToInt32(Console.ReadLine());

                //Opcja wyjścia z aplikacji

                switch (menuOption)
                {
                    case 1:
                        downloadFileOption();
                        break;
                    case 2:
                        saveLetterCount = letterCounter();
                        break;
                    case 3:
                        saveWordsCount = wordsCounter();
                        break;
                    case 4:
                        saveznakiRazem = punctuationsCounter();
                        break;
                    case 5:
                        saveSentecesCount = sentecesCounter();
                        break;
                    case 6:
                        raportGenerate();
                        break;
                    case 7:
                        saveAllData(saveLetterCount, saveWordsCount,  saveSentecesCount, saveznakiRazem);
                        break;
                    case 8:
                        continueProgram = 0;
                        deleteAll();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}