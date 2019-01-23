using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Topnet_v1.Models
{
    public class reqkpiModel : DbContext
    {

    
        public string nomKPI { get; set; }

        public string gouvernerat { get; set; }

        public DateTime dateDeb { get; set; }


        public DateTime dateFin { get; set; }
    }
}