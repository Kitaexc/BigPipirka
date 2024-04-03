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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private UNLV_STOREEntities context = new UNLV_STOREEntities();
        public Page2()
        {
            InitializeComponent();
            Clients.ItemsSource = context.Clients.ToList();
            Vibor.ItemsSource = context.Clients.ToList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Clients.ItemsSource = context.Clients.ToList().Where(item => item.ClientName.Contains(Poisk.Text));
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vibor.SelectedItem != null)
            {
                var selected = Vibor.SelectedItem as Clients;
                Clients.ItemsSource = context.Clients.ToList().Where(item => item.ClientSurName == selected.ClientSurName);
            }
        }
        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            Clients.ItemsSource = context.Clients.ToList();
        }

    }
}
