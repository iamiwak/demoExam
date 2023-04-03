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
using System.Windows.Shapes;

using Culteries.Base;

namespace Culteries
{
    public partial class MainWindow : Window
    {
        private CulteriesEntities _db = SourceCore.DataBase;

        public MainWindow()
        {
            InitializeComponent();
            List<Product> products = _db.Product.ToList();

            foreach (Product product in products)
            {
                Border border = new Border();
                border.Padding = new Thickness(12);

                Grid grid = new Grid();

                string defaultImageDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + @"\Images\picture.png";
                Image image = new Image
                {
                    // Check if `product` has image
                    Source = new BitmapImage(new Uri(defaultImageDirectory)),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Width = 96
                };
                grid.Children.Add(image);

                StackPanel stackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                TextBlock nameTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = string.IsNullOrEmpty(product.ProductName) ? "Товар без названия" : product.ProductName
                };

                TextBlock descriptionTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = string.IsNullOrEmpty(product.ProductDescription) ? "Товар без описания" : product.ProductDescription
                };

                TextBlock manafacturerTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = "Производитель: " + product.Manafactures.name
                };

                TextBlock priceTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Text = "Цена: " + product.ProductCost.ToString()
                };

                stackPanel.Children.Add(nameTextBlock);
                stackPanel.Children.Add(descriptionTextBlock);
                stackPanel.Children.Add(manafacturerTextBlock);
                stackPanel.Children.Add(priceTextBlock);
                grid.Children.Add(stackPanel);

                TextBlock quantityTextBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                if (product.ProductQuantityInStock == 0)
                {
                    quantityTextBlock.Text = "Нет на складе";
                    border.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#eeeeee");
                } else
                {
                    quantityTextBlock.Text = $"Осталось на складе: {product.ProductQuantityInStock}";
                }
                grid.Children.Add(quantityTextBlock);

                border.Child = grid;

                border.MouseLeftButtonDown += OnProductClick;

                GoodsBlock.Children.Add(border);
            }
        }

        private void OnProductClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Show editing page");
        }
    }
}
