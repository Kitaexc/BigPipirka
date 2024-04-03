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

namespace BigPipirka
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        private UNLV_STOREEntities context = new UNLV_STOREEntities();
        public Page4()
        {
            InitializeComponent();
            Products.ItemsSource = context.Products.ToList();
            Vibor.ItemsSource = context.Products.ToList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Products.ItemsSource = context.Products.ToList().Where(item => item.ProductName.Contains(Poisk.Text));
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vibor.SelectedItem != null)
            {
                var selected = Vibor.SelectedItem as Products;
                Products.ItemsSource = context.Products.ToList().Where(item => item.ProductName == selected.ProductName);
            }
        }
        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            Products.ItemsSource = context.Products.ToList();
        }

    }
}
