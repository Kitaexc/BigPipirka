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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private UNLV_STOREEntities context = new UNLV_STOREEntities();
        public Page1()
        {
            InitializeComponent();
            ClientTags.ItemsSource = context.ClientTags.ToList();
            Vibor.ItemsSource = context.ClientTags.ToList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ClientTags.ItemsSource = context.ClientTags.ToList().Where(item => item.TagName.Contains(Poisk.Text));
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vibor.SelectedItem != null)
            {
                var selected = Vibor.SelectedItem as ClientTags;
                ClientTags.ItemsSource = context.ClientTags.ToList().Where(item => item.TagName == selected.TagName);
            }
        }
        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            ClientTags.ItemsSource = context.ClientTags.ToList();
        }

    }
}
