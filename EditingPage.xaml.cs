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
using System.Windows.Shapes;

using Culteries.Base;

namespace Culteries
{
    public partial class EditingPage : Window
    {
        private bool _isNewitem = true;
        private Product _product;
        private CulteriesEntities _db = SourceCore.DataBase;

        public EditingPage(Product product = null)
        {
            InitializeComponent();

            _product = product;
            CategoryComboBox.ItemsSource = _db.Category.ToList();
            ProviderComboBox.ItemsSource = _db.Providers.ToList();

            if (_product != null)
            {
                _isNewitem = false;
                FillInformation();
            }
        }

        private void FillInformation()
        {
            NameTextBlock.Text = _product.ProductName;
            CategoryComboBox.SelectedItem = _product.Category;
            QuantityTextBlock.Text = _product.ProductQuantityInStock.ToString();
            ProviderComboBox.SelectedItem = _product.Providers;
            CostTextBlock.Text = _product.ProductCost.ToString();
            DescriptionTextBlock.Text = _product.ProductDescription;
        }

        private void OnChangeItemClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure for apply changes?", "Apply changes", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            string name = NameTextBlock.Text,
                quantityText = QuantityTextBlock.Text,
                description = DescriptionTextBlock.Text,
                costText = CostTextBlock.Text;

            bool isParsedQuantity = int.TryParse(quantityText, out int quantity);
            if (!isParsedQuantity || quantity < 0)
            {
                MessageBox.Show("Incorrect quantity!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isParsedCost = decimal.TryParse(costText, out decimal cost);
            if (!isParsedCost || cost < 0)
            {
                MessageBox.Show("Incorrect cost!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || CategoryComboBox.SelectedIndex == -1 || ProviderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Incorrect data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_isNewitem) _product = new Product();

            _product.ProductName = name;
            _product.ProductCategoryID = (CategoryComboBox.SelectedItem as Category).id;
            _product.ProductQuantityInStock = quantity;
            _product.ProductProviderID = (ProviderComboBox.SelectedItem as Providers).id;
            _product.ProductCost = cost;
            _product.ProductDescription = description;
            _product.ProductManufacturerID = 1;

            if (_isNewitem) _db.Product.Add(_product);
            try
            {
                _db.SaveChanges();
                DialogResult = true;
            } catch (Exception err)
            {
                MessageBox.Show($"Something went wrong, please message administrator!\n\nUnable to save data (EP.x.cs | 84)\n\n{err}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void OnCancelChangesClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure for cancel changes?", "Cancel changes", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Close();
        }
    }
}
