namespace WordSearcher.TextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using WordSearcher.DataObjects;

    /// <summary>
    /// Class for handling text files.
    /// </summary>
    internal static class FileHandler
    {
        public static List<string> strList = new List<string>();

        /// <summary>
        ///  Reads and saves the text files as strings and adds them to a list.
        /// </summary>
        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            string textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            string textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            strList.Add(ConvertToASCII(textOne));
            strList.Add(ConvertToASCII(textTwo));
            strList.Add(ConvertToASCII(textThree));
        }

        /// <summary>
        /// Creates DocumentObjects of each text files in the list.
        /// </summary>
        public static void CreateDocumentObjects(List<string> textList)
        {
            foreach (var item in textList)
            {
                DocumentObject document = new DocumentObject(item);
                DocumentObject.docObjList.Add(document);
            }
        }

        /// <summary>
        /// Encodes string to ASCII in case of unknown character in text.
        /// Solution URL: https://stackoverflow.com/questions/123336/how-can-you-strip-non-ascii-characters-from-a-string-in-c
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string encoded to ASCII</returns>
        private static string ConvertToASCII(string text)
        {
            return Encoding.ASCII.GetString(
                   Encoding.Convert(
                   Encoding.UTF8,
                   Encoding.GetEncoding(
                   Encoding.ASCII.EncodingName, new EncoderReplacementFallback(string.Empty), new DecoderExceptionFallback()),
                   Encoding.UTF8.GetBytes(text)));
        }
    }
}