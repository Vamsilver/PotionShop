using PotionShop.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionShop.ClassApp
{
    public class DBConnection
    {
        public static PotionShopEntities Connection = new PotionShopEntities();
    }
}
