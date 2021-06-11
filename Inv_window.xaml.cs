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
        Database1Entities db;
        EQP eqp = new EQP();
        public Inv_window()
        {
            InitializeComponent();
            db = new Database1Entities();

            List<Equip> mn = db.Database.SqlQuery<Equip>("Select*from Equip Where name = 'Монитор'").ToList();
            Monitor_Count.Text = Convert.ToString(mn.Count);

            List<Equip> ch = db.Database.SqlQuery<Equip>("Select*from Equip Where name = 'Стул'").ToList();
            Chair_Count.Text = Convert.ToString(ch.Count);

            List<Equip> tb = db.Database.SqlQuery<Equip>("Select*from Equip Where name = 'Стол'").ToList();
            Table_Count.Text = Convert.ToString(tb.Count);

            List<Equip> cp = db.Database.SqlQuery<Equip>("Select*from Equip Where name = 'Компьютер'").ToList();
            Computer_Case_Count.Text = Convert.ToString(cp.Count);

            Cb_CabInv.SelectedIndex = 0;

            InvGrid.ItemsSource = db.Equip.ToList();
        }
        public static string selectedCabinet { get; set; }
        private void Cb_CabInv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db = new Database1Entities();

            if (Cb_CabInv.SelectedIndex == 0)
            {
                Monitor_Count.Text = db.Equip.Where(w => w.name == "Монитор").Count().ToString();
                Chair_Count.Text = db.Equip.Where(db => db.name == "Стул").Count().ToString();
                Table_Count.Text = db.Equip.Where(db => db.name == "Стол").Count().ToString();
                Computer_Case_Count.Text = db.Equip.Where(db => db.name == "Компьютер").Count().ToString();
                selectedCabinet = "0";
                InvGrid.ItemsSource = db.Equip.ToList();
            }
            else if (Cb_CabInv.SelectedIndex == 1)
            {
                Monitor_Count.Text = db.Equip.Where(db => db.name == "Монитор" && db.cab == "1").Count().ToString();
                Chair_Count.Text = db.Equip.Where(db => db.name == "Стул" && db.cab == "1").Count().ToString();
                Table_Count.Text = db.Equip.Where(db => db.name == "Стол" && db.cab == "1").Count().ToString();
                Computer_Case_Count.Text = db.Equip.Where(db => db.name == "Компьютер" && db.cab == "1").Count().ToString();
                selectedCabinet = "1";
                InvGrid.ItemsSource = db.Equip.ToList();
            }
            else if (Cb_CabInv.SelectedIndex == 2)
            {
                Monitor_Count.Text = db.Equip.Where(db => db.name == "Монитор" && db.cab == "2").Count().ToString();
                Chair_Count.Text = db.Equip.Where(db => db.name == "Стул" && db.cab == "2").Count().ToString();
                Table_Count.Text = db.Equip.Where(db => db.name == "Стол" && db.cab == "2").Count().ToString();
                Computer_Case_Count.Text = db.Equip.Where(db => db.name == "Компьютер" && db.cab == "2").Count().ToString();
                selectedCabinet = "2";
                InvGrid.ItemsSource = db.Equip.ToList();
            }
            else if (Cb_CabInv.SelectedIndex == 3)
            {
                Monitor_Count.Text = db.Equip.Where(db => db.name == "Монитор" && db.cab == "3").Count().ToString();
                Chair_Count.Text = db.Equip.Where(db => db.name == "Стул" && db.cab == "3").Count().ToString();
                Table_Count.Text = db.Equip.Where(db => db.name == "Стол" && db.cab == "3").Count().ToString();
                Computer_Case_Count.Text = db.Equip.Where(db => db.name == "Компьютер" && db.cab == "3").Count().ToString();
                selectedCabinet = "3";
                InvGrid.ItemsSource = db.Equip.ToList();
            }
        }
        private void Monitor_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.cab == selectedCabinet && d.name == "Монитор").ToList();
            }
            else
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.name == "Монитор").ToList();
            }
        }
        private void Table_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.cab == selectedCabinet && d.name == "Стол").ToList();
            }
            else
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.name == "Стол").ToList();
            }
        }
        private void Chair_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.cab == selectedCabinet && d.name == "Стул").ToList();
            }
            else
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.name == "Стул").ToList();
            }
        }
        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.cab == selectedCabinet && d.name == "Компьютер").ToList();
            }
            else
            {
                InvGrid.ItemsSource = db.Equip.Where(d => d.name == "Компьютер").ToList();
            }
        }
        private void Insert(object sender, RoutedEventArgs e)
        {
            if (eqp.Add(Cb_Equip.SelectedIndex.ToString(), Cb_Cab.Text) == true)
            {
                Cb_Cab.SelectedIndex = -1;
                Cb_Equip.SelectedIndex = -1;
            }
            Monitor_Count.Text = db.Equip.Where(w => w.name == "Монитор").Count().ToString();
            Chair_Count.Text = db.Equip.Where(db => db.name == "Стул").Count().ToString();
            Table_Count.Text = db.Equip.Where(db => db.name == "Стол").Count().ToString();
            Computer_Case_Count.Text = db.Equip.Where(db => db.name == "Компьютер").Count().ToString();
            selectedCabinet = "0";
            InvGrid.ItemsSource = db.Equip.ToList();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            Equip equipment = InvGrid.SelectedItem as Equip;
            if (InvGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали кабинет", "Инвентаризация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Equip.Where(i => i.Id == equipment.Id).FirstOrDefault();
            eqp.Delete(equipment != null ? equipment.Id.ToString() : "0");
            Monitor_Count.Text = db.Equip.Where(w => w.name == "Монитор").Count().ToString();
            Chair_Count.Text = db.Equip.Where(db => db.name == "Стул").Count().ToString();
            Table_Count.Text = db.Equip.Where(db => db.name == "Стол").Count().ToString();
            Computer_Case_Count.Text = db.Equip.Where(db => db.name == "Компьютер").Count().ToString();
            selectedCabinet = "0";
            InvGrid.ItemsSource = db.Equip.ToList();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Database1Entities();
            InvGrid.ItemsSource = db.Equip.ToList();
        }
    }
}
