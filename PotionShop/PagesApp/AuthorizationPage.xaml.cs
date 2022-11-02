using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            EventLogin();
        }

        public void EventLogin()
        {
            try
            {
                if ((TxtLogin.Text != "") && (TxtPassword.Password != ""))
                {
                    var DataLogin = DBConnection.Connection.Authorization.Where(z => z.Login == TxtLogin.Text && z.Password == TxtPassword.Password).FirstOrDefault();
                    if (DataLogin != null)
                    {
                        TxtLogin.Text = "";
                        switch (DataLogin.User.IdRole)
                        {
                            case 1:
                                 NavigationService.Navigate(new SalesManagerWorkPage());
                                break;
                            case 2:
                                NavigationService.Navigate(new EmployeeWorkPage());
                                break;
                            case 3:
                                NavigationService.Navigate(new ShoppingManagerWorkPage());
                                break;
                        }
                           
                            
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                EventLogin();
        }
    }
}
