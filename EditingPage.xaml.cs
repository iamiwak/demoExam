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
        private CulteriesEntities _db = SourceCore.DataBase;

        public EditingPage()
        {
            InitializeComponent();
            CategoryComboBox.ItemsSource = _db.Category.ToList();
        }

        private void OnChangeItemClick(object sender, RoutedEventArgs e)
        {
            string name = NameTextBlock.Text,
                quantityText = QuantityTextBlock.Text,
                description = DescriptionTextBlock.Text;

            bool isParsedQuantity = int.TryParse(quantityText, out int quantity);
            if (!isParsedQuantity || quantity < 0)
            {
                MessageBox.Show("Incorrect quantity!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {

            }
        }

        private void OnCancelChangesClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure for cancel changes?", "Cancel changes", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Close();
        }
    }
}
