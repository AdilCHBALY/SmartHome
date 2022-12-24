using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    internal class Zone
    {
        private int id_zone;
        private int id_apprt;
        private int id_zdetails;

        public Zone(int id_zone, int id_zdetails, int id_apprt)
        {
            this.id_zone = id_zone;
            this.id_zdetails = id_zdetails;
            this.id_apprt = id_apprt;
        }

        public Zone()
        {

        }

        public int Id_zone { get => id_zone; set => id_zone = value; }
        public int Id_apprt { get => id_apprt; set => id_apprt = value; }
        public int Id_zdetails { get => id_zdetails; set => id_zdetails = value; }
    }
}
