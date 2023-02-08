using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace textEditor
{
    public class Xml
    {
        public List<Battleship> deserialize(string path)
        {
            List<Battleship> result = new List<Battleship>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Battleship>));
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                result = (List<Battleship>)xmlSerializer.Deserialize(fs);
            }
            return result;
        }

        public void serialize(List<Battleship> battleships, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Battleship>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, battleships);
            }
        }
    }
}
