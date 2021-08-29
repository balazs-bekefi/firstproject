using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negyedikheti
{
    public class Model
    {
        internal List<Leaderbard> players = new List<Leaderbard>();
        persistance persis;
        public Model()
        {
            persis = new persistance();
        }
        internal void Export(string name, string point)
        {
            persis.Save(name, point);
        }
        internal void Import()
        {
            players = persis.Load();
        }
        internal void PontExport(string pont)
        {
            System.IO.StreamWriter write = new System.IO.StreamWriter("point.txt");
            write.WriteLine(pont);
            write.Close();
        }
        internal string PontImport()
        {
            System.IO.StreamReader read = new System.IO.StreamReader("point.txt");
            string asd = read.ReadLine();
            read.Close();
            return asd;
        }
    }
}
