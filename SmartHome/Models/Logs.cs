using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    internal class Logs
    {
        private int _id;
        private string _transiction;
        private string _date;
       

        public Logs(int id, string transiction, string date)
        {
            Id = id;
            Transiction = transiction;
            Date = date;
        }

        public int Id { get => _id; set => _id = value; }
        public string Transiction { get => _transiction; set => _transiction = value; }
        public string Date { get => _date; set => _date = value; }
    
    }
}
