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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((TxtLogin.Text != "") && (TxtName.Text != "") && (TxtPassword.Text != ""))
                {
                    if (DBConnection.Connection.Authorization.Where(z => z.Login == TxtLogin.Text).FirstOrDefault() == null)
                    {
                        User NewUser = new User();
                        Authorization NewLogin = new Authorization()
                        {
                            Login = TxtLogin.Text,
                            Password = TxtPassword.Text
                        };
                        NewUser.Authorization.Add(NewLogin);
                        NewUser.Name = TxtName.Text;
                        NewUser.IdRole = 1;
                        DBConnection.Connection.User.Add(NewUser);
                        DBConnection.Connection.SaveChanges();
                        NavigationService.GoBack();
                        MessageBox.Show("Успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Такой логин уже существует!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
