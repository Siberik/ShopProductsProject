using Microsoft.Win32;
using ShopProductsProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        Core db ;
        Product activeProduct;
        public UpdatePage(Core db, Product currentProduct)
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = db.context.ProductType.ToList();
            this.DataContext= currentProduct;
            activeProduct = currentProduct;
            this.db = db;
        }

        private void ChangeImageButtonClick(object sender, RoutedEventArgs e)
        {
           
            OpenFileDialog winDialog = new OpenFileDialog();

            if (winDialog.ShowDialog()==true)
            {
                Uri sourse = new Uri(winDialog.FileName);
                ProductImage.Source = new BitmapImage(sourse);
            }
            //Изменение значения поля в БД
            activeProduct.Image =$"/products/{System.IO.Path.GetFileName(winDialog.FileName)}";
            //Перенос файла
            string newfilename = "/Assets/Images";
            string appFolderPath = Directory.GetCurrentDirectory();
            Console.WriteLine(appFolderPath);
            appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

            newfilename = appFolderPath + newfilename + $"/products/{System.IO.Path.GetFileName(winDialog.FileName)}";

            if (!File.Exists(newfilename))
            {
File.Copy(winDialog.FileName, newfilename);
            }
            
        }

       

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
           db.context.SaveChanges();
            
            this.NavigationService.Navigate(new ProductPages());
        }
    }
}
