using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Person>> dbResultTask = Task.Run<IEnumerable<Person>>(() =>

                {
                List<Person> people = new List<Person>();
                using (UserDBContext dbcontext = new UserDBContext())
                {
                    List<Person> People = dbcontext.People.ToList();
                }
                return people;
            });

            Task<IEnumerable<Person>> loggeddata = dbResultTask.ContinueWith<IEnumerable<Person>>(x =>
            {
                var _people = x.Result;
                LogData(_people);
                return _people;
            });

            var c = SynchronizationContext.Current;
            loggeddata.ContinueWith(x =>
            {
                c.Send((y) =>
                {
                    dataGridView1.DataSource = x.Result;
                }, null);
            });

        }

        private void LogData(IEnumerable<Person> people)
        {
            StringBuilder loginfo = new StringBuilder();
            foreach(Person person in people)
            {
                loginfo.Append(person);

            }
            File.WriteAllText("log.txt", loginfo.ToString());
        }
    }
}
