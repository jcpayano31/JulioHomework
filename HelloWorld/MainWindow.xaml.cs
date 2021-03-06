﻿using System;
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


namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;

        }



        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {      
           
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            Loging_text_Field_Validation();
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Loging_text_Field_Validation();
        }

        private void Loging_text_Field_Validation()
        {
            if (String.IsNullOrEmpty(uxName.Text) || string.IsNullOrEmpty(uxPassword.Text))
                uxSubmit.IsEnabled = false;
            else
                uxSubmit.IsEnabled = true;
        }
    }
}
