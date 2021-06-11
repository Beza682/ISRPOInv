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

namespace ISRPOInv
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Inv_window : Window
    {
        Database1Entities db = new Database1Entities();
        public Inv_window()
        {
            InitializeComponent();
            db = new Database1Entities();
            Cb_CabInv.SelectedIndex = 0;
        }

        private void Cb_CabInv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Monitor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Computer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Database1Entities();
            InvGrid.ItemsSource = db.Equip.ToList();
        }

        private void Insert(object sender, RoutedEventArgs e)
        {

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
