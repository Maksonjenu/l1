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
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace laba_2_3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
       
        public Window1()
        {
            
            InitializeComponent();

            
            
            
           
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Name_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            name.SelectAll();
            
            
        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }
    }
}
