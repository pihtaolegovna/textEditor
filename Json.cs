using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textEditor
{
    internal class Json
    {
        public List<Battleship> deserialize(string path)
        {
            string text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Battleship>>(text);
        }

        public void serialize(List<Battleship> battleships, string path)
        {
           string json = JsonConvert.SerializeObject(battleships);
           File.WriteAllText(path, json);
        }
    }
}
