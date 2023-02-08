using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace textEditor
{
    internal class Menu
    {
        keyboard keyboard = new keyboard();

        private int x = 3;
        private int y = 3;

        private string[] strings;
        public List<Battleship>? battleships;
        private string label = "Что бы сохранить - F1, что бы выйти - Esc";

        keyboard Keyboard = new keyboard();
        FileSaver file = new FileSaver();

        public void menuControl ()
        {
            strings = scan(battleships);
            keyboard.OnChange += Detector;
            new Thread(keyboard.keyControl).Start();;
                printer(strings);
        }

        private string[] scan(List<Battleship> battleships)
        {
            string[] result = new string[battleships.Count * 5];
            int i = 0;

            foreach(Battleship battleship in battleships)
            {
                result[i] = battleship.Name;
                result[i + 1] = Convert.ToString(battleship.Displacement);
                result[i + 2] = Convert.ToString(battleship.Length);
                result[i + 3] = Convert.ToString(battleship.Speed);
                result[i + 4] = battleship.Armament;
                i = i+5;
            }
            return result;
        }

        private List<Battleship> bilder(string[] strings)
        {
            List<Battleship> result = new List<Battleship>();
            int i = 0;

            for(i = 0; i < strings.Length; i = i+5)
            {
                string[] data = new string[5];
                data[0] = strings[i];
                data[1] = strings[i+1];
                data[2] = strings[i+2];
                data[3] = strings[i+3];
                data[4] = strings[i+4];
                result.Add(new Battleship(data));
            }
            return result;
        }

        private void printer(string[] strings)
        {
            Console.Clear();
            Console.WriteLine(label);
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            for(int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
            Console.SetCursorPosition(x, y);
        }

        public void Detector(ConsoleKey consoleKey)
        {

            switch (consoleKey)
            {
                case ConsoleKey.F1: 
                    file.Serialization(bilder(strings));
                    break;
                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;
                case ConsoleKey.UpArrow: 
                    Console.CursorTop--;
                    break;
                case ConsoleKey.DownArrow:
                    Console.CursorTop++;
                    break;
                case ConsoleKey.RightArrow: 
                    Console.CursorLeft = Console.CursorLeft + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.CursorLeft = Console.CursorLeft + -1;
                    break;
                default:
                    editor(consoleKey);
                    x = Console.CursorLeft;
                    y = Console.CursorTop;
                    printer(strings);
                    break;
            }
        }
        private void editor (ConsoleKey consoleKey)
        {
            char[] fabric = new char[256];
            string s;

            if (Console.CursorTop -3 <= strings.Length)
            {
                s = strings[Console.CursorTop - 2];
                for (int i = 0; i < s.Length; i++)
                {
                    fabric[i] = Convert.ToChar(s[i]);
                }
                if (Console.CursorLeft < fabric.Length)
                {
                    if (consoleKey == ConsoleKey.Delete)
                    {
                        fabric = deleter(fabric, Console.CursorLeft);
                    }
                    fabric[Console.CursorLeft] = Convert.ToChar(consoleKey);
                }
                s = "";
                foreach (char c in fabric)
                {
                    s = s + c;
                }
                strings[Console.CursorTop - 2] = s;
            }
        }

        private char[] deleter(char[] old, int index)
        {
            int n = 0;
            
            char[] result = new char[256];
            for(int i = 0; i < old.Length; i++)
            {
                if(i != index)
                {
                    result[n] = old[i];
                    n++;
                }
                else
                {
                    i++;
                    result[n] = old[i];
                    n++;
                }
            }
            return result;
        }
    }
}
