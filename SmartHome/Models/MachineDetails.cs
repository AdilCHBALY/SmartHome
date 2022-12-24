using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    internal class MachineDetails
    {
        private int _id;
        private string _name;
        private string _type;

        public MachineDetails(int id, string name, string type)
        {
            Id = id;
            _name = name;
            Type = type;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
