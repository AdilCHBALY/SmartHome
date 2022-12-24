using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    internal class HomeMachine
    {
        private int _id;
        private bool _status;

        public HomeMachine(int id, bool status)
        {
            _id = id;
            _status = status;
        }

        public int Id { get => _id; set => _id = value; }
        public bool Status { get => _status; set => _status = value; }
    }
}
