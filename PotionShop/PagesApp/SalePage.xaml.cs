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
    /// Interaction logic for SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {
        PotionKeeping potionKeeping;
        UserAuth user;
        Discount discount;
        public SalePage()
        {
            InitializeComponent();
        }

        public SalePage(PotionKeeping potionKeeping, UserAuth user)
        {
            InitializeComponent();
            this.potionKeeping = potionKeeping;
            this.user = user;

            PotionTextBlock.Text = potionKeeping.Potion.ToString();
            StorageTextBlock.Text = potionKeeping.Storage.ToString();
            FillShop();
        }

        private void CountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Recalculation();
        }

        private void FillShop()
        {
            var data = DBConnection.Connection.BuyerShop.ToList();
            ComboBoxShop.ItemsSource = data;
        }

        private void PreliminaryCostTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            Recalculation();
        }

        private void Recalculation()
        {
            if(!PreliminaryCostTextBlock.Text.Equals(""))
            {
                try
                {
                    FinallyCostTextBlock.Text = (Convert.ToInt64(PreliminaryCostTextBlock.Text) / 100 *
                        (100 - Convert.ToInt32(DiscountTextBlock.Text.Remove(DiscountTextBlock.Text.Length - 1)))).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if(!CountTextBox.Text.Equals(""))
            {
                try
                {
                    var count = Convert.ToInt32(CountTextBox.Text);
                    discount = DBConnection.Connection.Discount.Where(x => x.RequiredQuantity >= count).FirstOrDefault();
                    DiscountTextBlock.Text = discount.DiscountValue.ToString() + "%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if(FieldValidation())
            {
                if (Convert.ToInt32(FinallyCostTextBlock.Text) != 0)
                {
                    var TempIdSale = DBConnection.Connection.Sale.ToList().Last().IdSale + 1;

                    Sale sale = new Sale()
                    {
                        IdSale = TempIdSale,
                        IdUser = user.IdUser,
                        IdBuyerShop = ((BuyerShop)(ComboBoxShop.SelectedItem)).IdBuyerShop,
                        IdPotion = potionKeeping.IdPotion,
                        IdStorage = potionKeeping.IdStorage,
                        Count = Convert.ToInt32(CountTextBox.Text),
                        IdDiscount = discount.IdDiscount,
                        Cost = Convert.ToInt32(FinallyCostTextBlock.Text)
                    };

                    DBConnection.Connection.Sale.Add(sale);
                    var data = DBConnection.Connection.PotionKeeping.Where(x => x.IdPotionKeeping == potionKeeping.IdPotionKeeping).FirstOrDefault();
                    data.Count -= Convert.ToInt32(CountTextBox.Text);
                    DBConnection.Connection.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Увеличьте стоимость");
                }
            }
            else 
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private bool FieldValidation()
        {
            return ComboBoxShop.SelectedItem != null && !CountTextBox.Text.Equals("") && !FinallyCostTextBlock.Text.Equals("");
        }
    }
}
