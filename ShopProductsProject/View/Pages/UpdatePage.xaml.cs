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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        Core db = new Core();
        public UpdatePage()
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = db.context.ProductType.ToList();
        }

        private void ChangeImageButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
