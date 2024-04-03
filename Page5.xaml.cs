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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        private UNLV_STOREEntities context = new UNLV_STOREEntities();
        public Page5()
        {
            InitializeComponent();
            Orders.ItemsSource = context.Orders.ToList();
            Vibor.ItemsSource = context.Orders.ToList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Poisk.Text, out int searchId))
            {
                Orders.ItemsSource = context.Orders.ToList().Where(item => item.ID_Client == searchId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите действительный ID клиента.");
            }
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vibor.SelectedItem != null)
            {
                var selected = Vibor.SelectedItem as Orders;
                Orders.ItemsSource = context.Orders.ToList().Where(item => item.OrderDate == selected.OrderDate);
            }
        }
        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            Orders.ItemsSource = context.Orders.ToList();
        }

    }
}
