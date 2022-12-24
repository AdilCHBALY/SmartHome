using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    internal class Machine
    {
        private int id;
        private bool Status;
        private int id_zone;
        private int id_details;

        public Machine(int id, bool status, int id_zone, int id_details)
        {
            this.Id = id;
            Status1 = status;
            this.Id_zone = id_zone;
            this.Id_details = id_details;
        }

        public int Id { get => id; set => id = value; }
        public bool Status1 { get => Status; set => Status = value; }
        public int Id_zone { get => id_zone; set => id_zone = value; }
        public int Id_details { get => id_details; set => id_details = value; }
    }
}
