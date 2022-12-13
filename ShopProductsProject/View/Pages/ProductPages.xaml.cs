using ShopProductsProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopProductsProject.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPages.xaml
    /// </summary>
    public partial class ProductPages : Page
    {
        Core db = new Core();
        public ProductPages()
        {
            InitializeComponent();
            DataListView.ItemsSource = GetRows();

        }
        /// <summary>
        /// Формирование данные для вывода 
        /// </summary>
        /// <returns>
        /// Возвращает все данные из таблицы
        /// </returns>
        private List<Product> GetRows()
        {
            List<Product> arrayProduct = db.context.Product.ToList();
            return arrayProduct;
        }
    }
}
