namespace WordSearcher
{
    using WordSearcher.View;

    internal static class Program
    {
        private static void Main()
        {
            Setup.InitializeFiles();

            Menu menu = new Menu();
            menu.Main(Setup.tree);
        }
    }
}