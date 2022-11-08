using PotionShop.ADOApp;
using PotionShop.ClassApp;
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

namespace PotionShop.PagesApp
{

    public partial class ReceptPage : Page
    {
        List<ConsumablesUsing> listConsumableUsing;
        List<Potion> listPotion;
        List<Consumable> listConsumable;

        Potion selectPotion;
        Consumable selectConsumable;

        UserAuth userAuth;

        string strSelectPotion = "";
        string strSelectConsumable = "";

        public ReceptPage(UserAuth user)
        {
            InitializeComponent();
            userAuth = user;
            RefreshPage();
        }

        public void RefreshPage()
        {
           

            SetConsumable();
            SetPotion();
   
        }

        public void SetConsumable()
        {
            listConsumable = new List<Consumable>();
            listConsumable = DBConnection.Connection.Consumable.ToList();
            foreach (Consumable item in listConsumable)
            {
                cmbBoxConsumable.Items.Add(item.Name);
         
            }
        }

        public void SetPotion()
        {
            listPotion = new List<Potion>();
            listPotion = DBConnection.Connection.Potion.ToList();
            foreach (Potion item in listPotion)
            {
                cmbBoxPotion.Items.Add(item.Name);
            }
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
          


            Production production = new Production();

            List<ConsumablesUsing> listConsumable = DBConnection.Connection.ConsumablesUsing.ToList();


            foreach (var item in listConsumable)
            {
                production.IdConsumablesUsing = item.IdConsumablesUsing;
            }



            production.IdUser = userAuth.IdUser;

            DBConnection.Connection.Production.Add(production);
            DBConnection.Connection.SaveChanges();

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
                  //  MessageBox.Show(item.IdPotion.ToString() + " " + item.Name);
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
                  //  MessageBox.Show(item.IdConsumable.ToString() + " " + item.Name);
                }
            }
            return index;
        }

        private void cmbBoxConsumable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strSelectConsumable = cmbBoxConsumable.SelectedItem.ToString();
            // MessageBox.Show(strSelectConsumable);
        }

        private void cmbBoxPotion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strSelectPotion = cmbBoxPotion.SelectedItem.ToString();
            // MessageBox.Show(strSelectPotion);
        }
    }
}
