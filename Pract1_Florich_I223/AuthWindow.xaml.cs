﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;
using Pract1_Florich_I223.DBmodel;
using Pract1_Florich_I223.Logic;

namespace Pract1_Florich_I223
{
    public partial class AuthWindow : Window
    {
        private IAuthService _authService;

        public AuthWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
            ShopDBEntities2 dbContext = new ShopDBEntities2();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxlogin.Text;
            string pass = tbxPass.Text;

            MessageBox.Show(login, pass);

            if (_authService.CheckData(login, pass))
            {
                // Создаем экземпляр окна DataGrid
                DataGrid dataGridWindow = new DataGrid();

                // Открываем окно DataGrid
                dataGridWindow.Show();

                // Закрываем текущее окно AuthWindow
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте правильность введённых данных в полях");
            }
        }
    }
}