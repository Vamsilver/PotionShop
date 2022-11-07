using PotionShop.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PotionShop.ClassApp;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PotionShop.PagesApp
{
    /// <summary>
    /// Interaction logic for EmployeeWorkPage.xaml
    /// </summary>
    public partial class EmployeeWorkPage : Page
    {

        List<ConsumablesUsing> listConsumableUsing;
        List<Potion> listPotion;
        List<Consumable> listConsumable;

        Potion selectPotion;
        Consumable selectConsumable;

        string strSelectPotion = "";
        string strSelectConsumable = "";

        public EmployeeWorkPage()
        {
            InitializeComponent();
            RefreshPage();
        }

        public void RefreshPage()
        {
            SetConsumable();
            SetPotion();
            SetCountConsumableUsing();
        }

        public void SetConsumable()
        {
            listConsumable = new List<Consumable>();
            listConsumable = DBConnection.Connection.Consumable.ToList();
            foreach (Consumable item in listConsumable)
            {
                cmbBoxConsumable.Items.Add(item.Name);
                selectConsumable = item;
            }
        }

        public void SetPotion()
        {
            listPotion = new List<Potion>();
            listPotion = DBConnection.Connection.Potion.ToList();
            foreach (Potion item in listPotion)
            {
                cmbBoxPotion.Items.Add(item.Name);
                selectPotion = item;
            }
        }

        public void SetCountConsumableUsing()
        {
         
        }


        private void Create_Consumable(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsumablePage());
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsumablesUsing newConsumableUsing = new ConsumablesUsing();


            newConsumableUsing.Count = Convert.ToInt32(txtCountConsumable.Text);
            newConsumableUsing.IdPotion = FindByNamePotion();
            newConsumableUsing.IdConsumable = FindByNameConsumable();

            DBConnection.Connection.ConsumablesUsing.Add(newConsumableUsing);

            DBConnection.Connection.SaveChanges();
            SetCountConsumableUsing();
            MessageBox.Show("success!");
        }

        public int FindByNamePotion()
        {
            int index = 0;

            foreach (Potion item in listPotion)
            {
                if (strSelectPotion == item.Name)
                {
                    index = item.IdPotion;
                }
            }
            return index;
        }

        public int FindByNameConsumable()
        {
            int index = 0;

            foreach (var item in listConsumable)
            {
                if (strSelectConsumable == item.Name)
                {
                    index = item.IdConsumable;
                }
            }
            return index;
        }

        private void cmbBoxConsumable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strSelectConsumable = cmbBoxConsumable.SelectedItem.ToString();
        }

        private void cmbBoxPotion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strSelectPotion = cmbBoxPotion.SelectedItem.ToString();
        }
    }
}
