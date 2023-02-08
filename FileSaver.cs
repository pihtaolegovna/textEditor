using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace textEditor
{
    internal class FileSaver
    {
        txt Txt = new txt();
        Json json = new Json();
        Xml xml = new Xml();
        Menu01 menu = new Menu01();
        public List<Battleship>? Deserialization()
        {
            string path = menu.menu01();
            string[] filesTipe = path.Split('.');
            foreach (string files in filesTipe)
            {
                switch (files)
                {
                    case "txt": return Txt.deserialize(path);

                    case "json": return json.deserialize(path);

                    case "xml": return xml.deserialize(path);

                    default:
                        break;
                }
                
            }
            return null;
        }

        public void Serialization(List<Battleship> battleships)
        {
            string path = menu.menu01();
            string[] filesTipe = path.Split('.');
            foreach (string files in filesTipe)
            {
                switch (files)
                {
                    case "txt":  Txt.serialize(battleships, path);
                        break;

                    case "json":  json.serialize(battleships, path);
                        break;

                    case "xml":  xml.serialize(battleships, path);
                        break;

                    default:
                        break;
                }

            }
            Process.GetCurrentProcess().Kill();
        }

    }
}
