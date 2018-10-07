using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class Person
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{id},{Name},{Surname}\n";
        }
    }
}
