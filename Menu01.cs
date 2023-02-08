using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace textEditor
{
    internal class Menu01
    {
        public string menu01()
        {
            Console.Clear();
            Console.WriteLine("Введите путь");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(2, 4);
            return Console.ReadLine();
        }
    }
}
