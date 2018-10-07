using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class UserDBContext : DbContext
    {
        public UserDBContext(): base("MyDB")
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
