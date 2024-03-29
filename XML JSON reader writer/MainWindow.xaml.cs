﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using Newtonsoft.Json;
namespace XML_JSON_reader_writer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> Cars = new List<Car>();
        public MainWindow()
        {
            
            InitializeComponent();
            DataGridInit();
        }

        private void BtnXMLWrite_Click(object sender, RoutedEventArgs e)
        {
            SaveXMLFile();
        }

        private void BtnXMLRead_Click(object sender, RoutedEventArgs e)
        {
            LoadXMLFile();
        }

        private void BtnJSONRead_Click(object sender, RoutedEventArgs e)
        {
            LoadJSONFile();
        }       

        private void BtnJSONWrite_Click(object sender, RoutedEventArgs e)
        {
            SaveJSONFile();
        }
    }
}
