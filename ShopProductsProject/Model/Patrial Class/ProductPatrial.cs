using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProductsProject.Model
{
    public partial class Product
    {
        public string ImagePath { get { return "/Assets/Images" + Image; } }
    }
}
