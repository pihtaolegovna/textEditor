using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textEditor
{
    internal class txt
    {
        public List<Battleship> deserialize(string path)
        {
            string[] file = File.ReadAllLines(path);
            List<Battleship> result = new List<Battleship>();
            for (int i = 0; i < file.Length; i=i+5)
            {
                string[] data = new string[5];
                data[0] = file[i];
                data[1] = file[i+1];
                data[2] = file[i+2];
                data[3] = file[i+3];
                data[4] = file[i+4];
                result.Add(new Battleship(data));
            }
            return result;
        }

        public void serialize(List<Battleship> battleships, string path)
        {
            string[] result = new string[battleships.Count * 5];
            int i =0;

            foreach( Battleship b in battleships)
            {
                result[i] =b.Name;
                result[i + 1] = Convert.ToString(b.Displacement);
                result[i + 2] = Convert.ToString(b.Length);
                result[i + 3] = Convert.ToString(b.Speed);
                result[i+4] = b.Armament;
                i = i + 5;
            }
            File.WriteAllLines(path, result);
        } 
    }
}
