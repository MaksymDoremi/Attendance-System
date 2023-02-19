using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS_Final.Objects
{
    public class Attendance
    {
        private int id;
        private string name;
        private string surname;
        private DateTime dateTime;
        private bool type;
        private string typeString;

        public Attendance(int iD, string name, string surname, DateTime dateTime, bool type)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            DateTime = dateTime;
            Type = type;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public bool Type { get => type; set => type = value; }

        public string TypeString { get => Type == true ? "Came" : "Left"; }
    }
}
