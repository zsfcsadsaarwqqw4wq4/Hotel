using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebProject.AppHelper
{
    public class DishesCategoryHelper
    {
        public int DishesId { get; set; }

        public string DishesName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}