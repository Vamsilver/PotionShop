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
    
    public partial class ShoppingManagerWorkPage : Page
    {
        List<ConsumableKeeping> keeping;
        public ShoppingManagerWorkPage()
        {
            InitializeComponent();
            RefreshPage();
        }

        public void RefreshPage()
        {
            keeping = new List<ConsumableKeeping>();
            keeping = DBConnection.Connection.ConsumableKeeping.ToList();
            foreach (ConsumableKeeping keep in keeping)
            {
                keep.Consumable = DBConnection.Connection.Consumable.Where(x => x.IdConsumable == keep.IdConsumable).FirstOrDefault();
                keep.Storage = DBConnection.Connection.Storage.Where(x => x.IdStorage == keep.IdStorage).FirstOrDefault();
            }
            ConsumableGrid.ItemsSource = keeping;
        }

        private void ConsumableGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(ConsumableGrid.SelectedItem != null)
            {
                if(e.Key == Key.Enter)
                {
                    var result = MessageBox.Show("Хотите заказать еще?", "Заказать еще", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        NavigationService.Navigate(new PurchasePage((ConsumableKeeping)ConsumableGrid.SelectedItem));
                        RefreshPage();
                    }
                }
            }
        }
    }
}
