using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moussadjal_mobile_app
{
    public class LocationModel
    {
        public string Id { get; set; }         // ID of the location from database
        public string Name { get; set; }       // Name of the location
        public string Description { get; set; } // Description of the location
        public int ItemCount { get; set; }     // Number of items in this location
    }
}
