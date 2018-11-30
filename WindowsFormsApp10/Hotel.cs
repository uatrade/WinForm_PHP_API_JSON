using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10
{
    public class Hotel
    {
        public int id { get; set; }
        public string hotelName { get; set; }
        public int cityId { get; set; }
        public int countryId { get; set; }
        public int? stars { get; set; }
        public int? cost { get; set; }
        public string info { get; set; }
    }
}
