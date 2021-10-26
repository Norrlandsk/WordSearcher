using WordSearcher.DataStructure;
using WordSearcher.TextFile;

namespace WordSearcher
{
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