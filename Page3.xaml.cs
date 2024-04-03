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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private UNLV_STOREEntities context = new UNLV_STOREEntities();
        public Page3()
        {
            InitializeComponent();
            ProductTypes.ItemsSource = context.ProductTypes.ToList();
            Vibor.ItemsSource = context.ProductTypes.ToList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ProductTypes.ItemsSource = context.ProductTypes.ToList().Where(item => item.PrType.Contains(Poisk.Text));
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vibor.SelectedItem != null)
            {
                var selected = Vibor.SelectedItem as ProductTypes;
                ProductTypes.ItemsSource = context.ProductTypes.ToList().Where(item => item.PrType == selected.PrType);
            }
        }
        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            ProductTypes.ItemsSource = context.ProductTypes.ToList();
        }

    }
}
