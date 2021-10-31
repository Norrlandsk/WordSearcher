namespace WordSearcher
{
    using WordSearcher.DataStructure;
    using WordSearcher.TextFile;

    /// <summary>
    /// Class for initializing necessary objects for the application.
    /// </summary>
    internal static class Setup
    {
        public static Tree tree = new Tree();

        public static void InitializeFiles()
        {
            FileHandler.ReadFiles();
            FileHandler.CreateDocumentObjects(FileHandler.strList);
        }
    }
}