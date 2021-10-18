using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WordSearcher.TextFile
{
    internal class FileHandler
    {
        public static string textOne;
        public static string textTwo;
        public static string textThree;

        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            textOne = System.IO.File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            textTwo = System.IO.File.ReadAllText(@"C:\Users\Studera\source\repos\WordSearcher\WordSearcher\TextFiles\Text_2.txt");
            textThree = System.IO.File.ReadAllText(@"C:\Users\Studera\source\repos\WordSearcher\WordSearcher\TextFiles\Text_3.txt");

            Console.WriteLine(textOne);
            //Console.WriteLine(textTwo);
            //Console.WriteLine(textThree);
            //Hej på dig

        }





        
    }
}
