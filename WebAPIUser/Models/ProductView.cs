using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    public class ProductView
    {
        public string type { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string img { get; set; }
        public bool active { get; set; }
    }
}
