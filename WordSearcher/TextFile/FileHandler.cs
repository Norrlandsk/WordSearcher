namespace WordSearcher.TextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using WordSearcher.DataObjects;

    /// <summary>
    /// Class for handling text files. Reads and saves them as strings and adds them to a list.
    /// Creates DocumentObjects of each text files in the list.
    /// </summary>
    internal static class FileHandler
    {
        public static List<string> strList = new List<string>();

        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            string textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            string textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            strList.Add(textOne);
            strList.Add(textTwo);
            strList.Add(textThree);
        }

        public static void CreateDocumentObject(List<string> textList)
        {
            foreach (var item in textList)
            {
                DocumentObject document = new DocumentObject(item);
                DocumentObject.docObj.Add(document);
            }
        }
    }
}