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
    /// <summary>
    /// Interaction logic for PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        ConsumableKeeping consumableKeeping;

        public PurchasePage()
        {
            InitializeComponent();
        }

        public PurchasePage(ConsumableKeeping consumableKeeping)
        {
            InitializeComponent();
            this.consumableKeeping = consumableKeeping;

            IdTextBlock.Text = consumableKeeping.IdConsumable.ToString();
            NameTextBlock.Text = consumableKeeping.Consumable.Name;
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if(CountTextBox.Text.Equals(""))
            {
                MessageBox.Show("Введите количество!");
            }
            else
            {
                try
                {
                    var data = DBConnection.Connection.ConsumableKeeping.Where(x => x.IdConsumableKeeping == consumableKeeping.IdConsumableKeeping).FirstOrDefault();
                    data.Count += Convert.ToInt32(CountTextBox.Text);   
                    DBConnection.Connection.SaveChanges();
                    NavigationService.GoBack();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
