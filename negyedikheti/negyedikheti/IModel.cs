using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negyedikheti
{
    interface IModel
    {
        void Save(string name, string score);
        List<Leaderbard> Load();
        void PontExport(string pont);
        string PontImport();
        List<string> data { get; }
    }
}
