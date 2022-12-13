﻿using ShopProductsProject.Model;
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
        int page = 1;
        Core db = new Core();
        //Количество элементов на странице
        int countElement = 10;
        public ProductPages()
        {
            InitializeComponent();



            UpdateUI();
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
        /// <summary>
        /// Подсчёт количества страниц,в пагинции
        /// </summary>
        /// <returns>
        /// Возвращение целочисленного значения количества страниц
        /// </returns>
        private int GetPagesCount()
        {
            int countPage = 0;

            int count = GetRows().Count;
            if (count > countElement)
            {
                countPage = Convert.ToInt32(Math.Ceiling(count * 1.0 / countElement));
            }
            return countPage;
        }
        /// <summary>
        /// Вывод кнопок пагинации
        /// </summary>
        /// <param name="page">
        /// Количество страниц
        /// </param>
        public void DisplayPagination(int page)
        {
            List<PageItem> source = new List<PageItem>();
            for (int i = 1; i < GetPagesCount(); i++)
            {
                source.Add(new PageItem(i, i == page));
            }
            PaginationListView.ItemsSource = source;
            PrevTextBlock.Visibility = (page <= 1 ? Visibility.Hidden : Visibility.Visible);
            NextTextBlock.Visibility = (page >= GetPagesCount() ? Visibility.Hidden : Visibility.Visible);
        }
        /// <summary>
        /// Событие, при нажатии на текст
        /// </summary>
        private void TextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            page = Convert.ToInt32(textBlock.Text);
            UpdateUI();
        }

        private void PrevTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (page <= 1)
            {
                page = 1;
                PrevTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                page -= 1;
                PrevTextBlock.Visibility = Visibility.Visible;

            }
            UpdateUI();


        }

        private void NextTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (page >= GetPagesCount())
            {
                page = GetPagesCount();
                NextTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                page += 1;
                NextTextBlock.Visibility = Visibility.Visible;
            }
            UpdateUI();


        }
        private void UpdateUI()
        {
            if (GetRows().Count > 10)
            {
                DisplayPagination(page);
                List<Product> displayProduct = GetRows().Skip((page - 1) * countElement).Take(countElement).ToList();

                DataListView.ItemsSource = displayProduct;
            }
            else
            {
                PaginationListView.Visibility = Visibility.Collapsed;
            }
        }
    }
}
