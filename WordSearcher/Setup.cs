using WordSearcher.DataStructure;
using WordSearcher.TextFile;

namespace WordSearcher
{
    /// <summary>
    /// Class for initializing necessary objects for the application.
    /// </summary>
    internal class Setup
    {
        public Tree InitializeTree()
        {
            Tree tree = new Tree();
            return tree;
        }

        public void InitializeFiles()
        {
            FileHandler.ReadFiles();
            FileHandler.CreateDocumentObject(FileHandler.strList);
        }
    }
}