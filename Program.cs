namespace textEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileSaver fileSaver = new FileSaver();
            Menu menu = new Menu();
            keyboard keyboard = new keyboard();

            menu.battleships = fileSaver.Deserialization();
            menu.menuControl();

        }
    }
}