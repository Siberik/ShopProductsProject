using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProductsProject.Model
{
    public partial class Product
    {
        public string ImagePath { get { 
                if(Image==null)
                {
                    return "/Assets/Images/picture.png";
                }
                else
                {
        return "/Assets/Images" + Image;
                }

                 } }

    }
}
