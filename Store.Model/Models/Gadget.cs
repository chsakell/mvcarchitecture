using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Model.Models;

namespace Store.Model
{
    public class Gadget
    {
        public int GadgetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
