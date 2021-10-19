using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WordSearcher.TextFile
{
    internal class FileHandler
    {
        public static string textOne;
        public static string textTwo;
        public static string textThree;

        public static List<string> strList = new List<string>();
        public static List<string> strListOne = new List<string>();
        public static List<string> strListTwo = new List<string>();
        public static List<string> strListThree = new List<string>();

        public static string[] wordsOne;
        public static string[] wordsTwo;
        public static string[] wordsThree;
        public static List<string[]> wordsList = new List<string[]>();

        public static char[] delimiterChars = { ' ', ',', '.', ':', '—', '-', ';' };





        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            strList.Add(textOne);
            strList.Add(textTwo);
            strList.Add(textThree);

        }


        public static void AddStringsToList(List<string> str)
        {
            //wordsOne = textOne.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            //wordsTwo = textTwo.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            //wordsThree = textThree.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            //wordsOne = System.Text.RegularExpressions.Regex.Split(textOne, pattern);

            wordsList.Add(wordsOne);
            //wordsList.Add(wordsTwo);
            //wordsList.Add(wordsThree);
        }





        public static void SearchForWord(string userInput)
        {
            int counter = 0;

            for (int i = 0; i < wordsList.Count; i++)
            {
                foreach (var item in wordsList[i])
                {

                    if (string.Equals(userInput, item, StringComparison.OrdinalIgnoreCase))
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
                counter = 0;

            }







            foreach (var item in wordsOne)
            {
                Console.WriteLine(item);
            }
        }

        public static void SearchForWord2()
        {
            string pattern = $@"\b\w+natural\b";
            Regex rgx = new Regex(pattern);
            int counter = 0;

            foreach (Match match in rgx.Matches(textOne))
            {
                counter++;
            }

            Console.WriteLine(counter);
        }



        public static void countTrue(string data)
        {
            
            Console.WriteLine(Regex.Matches(textOne, data).Count());
        }











    }
}
