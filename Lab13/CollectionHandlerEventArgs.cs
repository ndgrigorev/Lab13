using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class CollectionHandlerEventArgs: EventArgs
    {
        public string Name { get; set; }
        public string TypeOfChange { get; set; }
        public object ObjectChange { get; set; }

        public CollectionHandlerEventArgs(string name, string typeOfChange, object objectChange)
        {
            Name = name;
            TypeOfChange = typeOfChange;
            ObjectChange = objectChange;
        }
    }
}
