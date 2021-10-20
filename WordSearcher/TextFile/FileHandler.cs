﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WordSearcher.DataStructure;

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

        public static char[] delimiterChars = { ' ', ',', '.', ':' };

        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            DocumentObject d1 = new DocumentObject(textOne, DocumentObject.SetID());
            DocumentObject d2 = new DocumentObject(textTwo, DocumentObject.SetID());
            DocumentObject d3 = new DocumentObject(textThree, DocumentObject.SetID());

            strList.Add(textOne);
            strList.Add(textTwo);
            strList.Add(textThree);
        }

        public static void AddStringsToList(List<string> str)
        {
            wordsOne = textOne.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            wordsTwo = textTwo.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            wordsThree = textThree.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            wordsList.Add(wordsOne);
            wordsList.Add(wordsTwo);
            wordsList.Add(wordsThree);
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

            //foreach (var item in wordsTwo)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public static void SearchForWord2(string userInput)
        {
            int counter = 0;

            for (int i = 0; i < wordsOne.Length; i++)
            {
                if (userInput == wordsOne[i])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}