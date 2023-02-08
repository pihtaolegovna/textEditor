using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textEditor
{
    public class Battleship
    {
        public string Name;
        public int Displacement;
        public int Length;
        public int Speed;
        public string Armament;

        public Battleship(string[] data)
        {
            this.Name = data[0];
            this.Displacement = Convert.ToInt32(data[1]);
            this.Length = Convert.ToInt32(data[2]);
            this.Speed = Convert.ToInt32(data[3]);
            this.Armament = data[4];
        }
    }
}
