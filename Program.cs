using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prakt16
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                char[] separators = new char[] { ' ', '.', ':', '…' };
                string text = "";

                using (StreamReader rd = File.OpenText("file.txt"))
                {
                    text += rd.ReadLine();
                }

                string[] proposal = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string inputText = "";
                while (inputText == "")
                {
                    Console.Write("Введите слово: ");
                    inputText = Console.ReadLine();
                }

                int countWords = (from word in proposal
                            where word.ToLower() == inputText.ToLower()
                            select word).Count();

                Console.WriteLine($"были найдены {countWords} вхождения (ий) " +
                    $"поискового запроса '{inputText}'");
            }
            catch
            {
                Console.WriteLine("ошибка неверного формата");
            }

            Console.ReadKey();
        }
    }
}
