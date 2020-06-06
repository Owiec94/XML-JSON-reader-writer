using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Serialization;
namespace XML_JSON_reader_writer
{
    public partial class MainWindow : Window
    {
        private void LoadJSONFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                FileName = "",
                Filter = "json (*.json)|*.json"
            };
            if (true == ofd.ShowDialog())
            {
                string Path = ofd.FileName; //C:\Users\file.xml

                ClearData();

                LoadJSONToList(Path);

                LoadDataToDataGrid();
            }
           
        }

        public class json
        {
          
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public int price { get; set; }
        }

        private void LoadJSONToList(string Path)
        {
            string JsonString = File.ReadAllText(Path);           
            
            var myObject = JsonConvert.DeserializeObject<List<Car>>(JsonString);

            int i = 1;
            foreach(var obj in myObject)
            {
                Cars.Add(new Car()
                {
                    Nbr = i + 1,
                    Brand = obj.Brand,
                    Model = obj.Model,
                    Color = obj.Color,
                    Price = obj.Price
                }) ;
                i++;
            }
        }
    }
}
