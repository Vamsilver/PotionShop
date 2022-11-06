﻿using PotionShop.ADOApp;
using PotionShop.ClassApp;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PotionShop.PagesApp
{
    public partial class ConsumablePage : Page
    {
        List<Consumable> listAllConsumable;
        List<TypeConsumable> listConsumable;
        List<UnitOfMeasurement> listMeasur;

        TypeConsumable selectConsum;
        UnitOfMeasurement selectMeasur;

        public ConsumablePage()
        {
            InitializeComponent();


            RefreshPage();

        }


        public void RefreshPage()
        {
            SetTypeConsumable();
            SetTypeMeasurement();
            SetListConsumable();
        }


        public void SetTypeConsumable()
        {
            listConsumable = new List<TypeConsumable>();
            listConsumable = DBConnection.Connection.TypeConsumable.ToList();
            foreach (TypeConsumable item in listConsumable)
            {
                cmbBoxTypeConsumable.Items.Add(item.TypeName);
                selectConsum = item;
            }
        }

        public void SetTypeMeasurement()
        {
            listMeasur = new List<UnitOfMeasurement>();
            listMeasur = DBConnection.Connection.UnitOfMeasurement.ToList();
            foreach (UnitOfMeasurement item in listMeasur)
            {
                cmbBoxUnitOfMeasurement.Items.Add(item.Name);
                selectMeasur = item;
            }
        }

        public void SetListConsumable()
        {
            listBoxTypeConsum.Items.Clear();
           listAllConsumable = new List<Consumable>();
            listAllConsumable = DBConnection.Connection.Consumable.ToList();
            foreach (Consumable item in listAllConsumable)
            {
                listBoxTypeConsum.Items.Add(item.Name);
            }
            //listBoxTypeConsum.ItemsSource = listAllConsumable;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Consumable newConsumable = new Consumable();


            newConsumable.Name = txtNameConsumable.Text;
            newConsumable.IdType = selectConsum.IdTypeConsumable;
            newConsumable.IdUnitOfMeasurement = selectMeasur.IdUnitOfMeasurement;

            DBConnection.Connection.Consumable.Add(newConsumable);

            DBConnection.Connection.SaveChanges();
            SetListConsumable();
            MessageBox.Show("success!");
        }

        private void cmbBoxTypeConsumable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //MessageBox.Show(selectConsum.TypeName);
     
        }

        private void cmbBoxUnitOfMeasurement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(selectConsum.TypeName);
          
        }
    }
}
