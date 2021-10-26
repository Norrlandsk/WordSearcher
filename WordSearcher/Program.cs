namespace WordSearcher
{
    using WordSearcher.DataStructure;
    using WordSearcher.View;

    internal static class Program
    {
        public static Tree tree = new Tree();

        private static void Main(string[] args)
        {
            Setup setup = new Setup();
            setup.InitializeFiles();

            Menu menu = new Menu();
            menu.Main(tree);
        }
    }
}
