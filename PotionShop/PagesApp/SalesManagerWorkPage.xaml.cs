using PotionShop.ADOApp;
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
using PotionShop.ClassApp;

namespace PotionShop.PagesApp
{
    /// <summary>
    /// Interaction logic for SalesManagerWorkPage.xaml
    /// </summary>
    public partial class SalesManagerWorkPage : Page
    {
        List<PotionKeeping> keeping;
        UserAuth userAuth;

        public SalesManagerWorkPage()
        {
            InitializeComponent();
            RefreshPage();
        }

        public SalesManagerWorkPage(UserAuth user)
        {
            InitializeComponent();
            userAuth = user;
            RefreshPage();
        }

        public void RefreshPage()
        {
            keeping = new List<PotionKeeping>();
            keeping = DBConnection.Connection.PotionKeeping.ToList();
            foreach (var keep in keeping)
            {
                keep.Potion  = DBConnection.Connection.Potion.Where(x => x.IdPotion == keep.IdPotion).FirstOrDefault();
                keep.Storage = DBConnection.Connection.Storage.Where(x => x.IdStorage == keep.IdStorage).FirstOrDefault();
            }
            PotionGrid.ItemsSource = keeping;
        }

        private void PotionGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OrderGoods();
            }
        }

        private void PotionGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderGoods();
        }

        private void OrderGoods()
        {
            if (PotionGrid.SelectedItem != null)
            {
                var result = MessageBox.Show("Хотите продать?", "Продажа", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    NavigationService.Navigate(new SalePage((PotionKeeping)PotionGrid.SelectedItem, userAuth));
                    RefreshPage();
                }
            }
        }
    }
}
