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

    
        List<Potion> listPotion;
        List<ConsumablesUsing> listConsumableUsing;

        List<Production> listProductions;

        List<PotionKeeping> listPotionKeeping;
        List<Storage> listStorage;

        Potion selectPotion;
        Consumable selectConsumable;

        UserAuth userAuth;

        string strSelectPotion = "";
        string strSelectStorage = "";

        public EmployeeWorkPage(UserAuth user)
        {
            InitializeComponent();
            RefreshPage();

            userAuth = user;
        }

        public void RefreshPage()
        {
            listBoxPotionKeeping.Items.Clear();
            listBoxProduct.Items.Clear();
            listBoxRecpts.Items.Clear();
            cmbBoxPotion.Items.Clear();
            cmbBoxStorage.Items.Clear();

            SetConsumableUsing();
            SetPotion();
            SetStorage();
            SetPotionKeeping();
            SetProduction();
        }

        public void SetConsumableUsing()
        {
            listConsumableUsing = new List<ConsumablesUsing>();
            listConsumableUsing = DBConnection.Connection.ConsumablesUsing.ToList();

            foreach (ConsumablesUsing item in listConsumableUsing)
            {
                listBoxRecpts.Items.Add(FindByIdPotion(item.IdPotion) + " | " + FindByIdConsumable(item.IdConsumable) + " | " + item.Count + " шт.");
            }
        }

        public void SetPotionKeeping()
        {
            listPotionKeeping = new List<PotionKeeping>();
            listPotionKeeping = DBConnection.Connection.PotionKeeping.ToList();

            foreach (PotionKeeping item in listPotionKeeping)
            {
                listBoxPotionKeeping.Items.Add(FindByIdPotion(item.IdPotion) + " | " + FindByIdStorage(item.IdStorage) + " | " + item.Count + " шт.");
            }
        }

        public void SetProduction()
        {
            listProductions = new List<Production>();
            listProductions = DBConnection.Connection.Production.ToList();

            foreach (Production item in listProductions)
            {
                listBoxProduct.Items.Add("№ " + item.IdConsumablesUsing + " | " + FindByIdUser(item.IdUser));
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

        public void SetStorage()
        {
            listStorage = new List<Storage>();
            listStorage = DBConnection.Connection.Storage.ToList();
            foreach (Storage item in listStorage)
            {
                cmbBoxStorage.Items.Add(item.Address);
            }
        }


        private void Create_Consumable(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsumablePage());
        }


        private void Create_Recept(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReceptPage(userAuth));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsumablesUsing newConsumableUsing = new ConsumablesUsing();

            


            //newConsumableUsing.Count = Convert.ToInt32(txtCountConsumable.Text);
            //newConsumableUsing.IdPotion = FindByNamePotion();
            //newConsumableUsing.IdConsumable = FindByNameConsumable();

            //DBConnection.Connection.ConsumablesUsing.Add(newConsumableUsing);

            //DBConnection.Connection.SaveChanges();
            //SetCountConsumableUsing();


            Production production = new Production();

            List<ConsumablesUsing> listConsumable =  DBConnection.Connection.ConsumablesUsing.ToList();


            foreach(var item in listConsumable)
            {
                production.IdConsumablesUsing = item.IdConsumablesUsing;
            }


          
            production.IdUser = userAuth.IdUser;

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
                }
            }
            return index;
        }

        public int FindByNameStorage()
        {
            int index = 0;

            foreach (var item in listStorage)
            {
                if (strSelectStorage == item.Address)
                {
                    index = item.IdStorage;
                }
            }
            return index;
        }

        public String FindByIdPotion(int idPotion)
        {
            listPotion = new List<Potion>();
            listPotion = DBConnection.Connection.Potion.ToList();
            String name = "";

            foreach (Potion item in listPotion)
            {
                if (idPotion == item.IdPotion)
                {
                    name = item.Name;
                }
            }
            return name;
        }

        public String FindByIdConsumable(int idConsumable)
        {
            List<Consumable> listConsumable = new List<Consumable>();
            listConsumable = DBConnection.Connection.Consumable.ToList();
            String name = "";

            foreach (Consumable item in listConsumable)
            {
                if (idConsumable == item.IdConsumable)
                {
                    name = item.Name;
                }
            }
            return name;
        }

        public String FindByIdStorage(int idStorage)
        {
            List<Storage> listStorage = new List<Storage>();
            listStorage = DBConnection.Connection.Storage.ToList();
            String name = "";

            foreach (Storage item in listStorage)
            {
                if (idStorage == item.IdStorage)
                {
                    name = item.Address;
                }
            }
            return name;
        }

        public String FindByIdUser(int idUser)
        {
            List<User> listPotion = new List<User>();
            listPotion = DBConnection.Connection.User.ToList();
            String name = "";

            foreach (User item in listPotion)
            {
                if (idUser == item.IdUser)
                {
                    name = item.Name;
                }
            }
            return name;
        }

        private void cmbBoxPotion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
       
            try
            {
                strSelectPotion = cmbBoxPotion.SelectedItem.ToString();
            }
            catch(Exception ex)
            {

            }
  
        }

        private void cmbBoxStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
       
            try
            {
                strSelectStorage = cmbBoxStorage.SelectedItem.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_StorageKeeping(object sender, RoutedEventArgs e)
        {

            PotionKeeping potionKeeping = new PotionKeeping();

            potionKeeping.IdStorage = FindByNameStorage();
            potionKeeping.IdPotion = FindByNamePotion();
            potionKeeping.Count = int.Parse(txtCntPotion.Text.ToString());

            DBConnection.Connection.PotionKeeping.Add(potionKeeping);
            DBConnection.Connection.SaveChanges();

            RefreshPage();

            //Consumable newConsumable = new Consumable();


            //newConsumable.Name = txtNameConsumable.Text;
            //newConsumable.IdType = FindByNameConsumable();
            //newConsumable.IdUnitOfMeasurement = FindByNameMeasurement();

            //DBConnection.Connection.Consumable.Add(newConsumable);

            //DBConnection.Connection.SaveChanges();
            //SetListConsumable();
            //MessageBox.Show("success!");
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }


    }
}
