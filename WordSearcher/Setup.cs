using System;
using System.Collections.Generic;
using System.Text;
using WordSearcher.DataStructure;
using WordSearcher.TextFile;

namespace WordSearcher
{
    class Setup
    {
        public void InitializeTree()
        {
            Tree tree = new Tree();
        }

        public void InitializeFiles()
        {
            FileHandler.ReadFiles();
            FileHandler.CreateDocumentObject(FileHandler.strList);
        }
    }
}
