using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var address = new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243");
            var person = new Person("Jane", "Smith", address);
            var biz = new Business("Alliance Reservations Network", address);

             
            person.Save();

            List<Person> list = Person.GetAll();

            string id = person.Id;
         
            biz.Save();

            Person savedPerson = Person.Find(person.Id);
           

            Address address1 = person.Address;
            

            Address addressnew = savedPerson.Address;
           

            bool b = address.Equals(addressnew);

            person.Save();
           

            //var dictionary = new Dictionary<object, object> { [address] = address, [person] = person, [biz] = biz };
            //bool f= dictionary.ContainsKey(new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243"));
            //Person p = new Person("Jane", "Smith", address);
            //bool s = dictionary.ContainsKey(p); ;
            //int m = 0;

            var deletedPersonId = person.Id;
            person.Delete();
            string numr = person.Id;
            Person p= Person.Find(deletedPersonId);
 

            var deletedBizId = biz.Id;
            biz.Delete();
            string num = biz.Id;
            Person h = Person.Find(deletedBizId);

          
        }
    }
}
