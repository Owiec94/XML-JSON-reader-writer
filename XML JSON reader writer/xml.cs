using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace XML_JSON_reader_writer
{
    public partial class MainWindow : Window
    {
        private void LoadXMLFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                FileName = "",
                Filter = "XML (*.xml)|*.xml"
            };
            if (true == ofd.ShowDialog())
            {
                string Path = ofd.FileName; //C:\Users\file.xml

                ClearData();

                LoadXMLToList(Path);

                LoadDataToDataGrid();
            }
        }

        private void SaveToXML(string Path)
        {
            XmlWriterSettings XmlSet = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };

            XmlWriter Xml = XmlWriter.Create(Path, XmlSet);

            Xml.WriteStartDocument();

            Xml.WriteStartElement("cars");
            List<String> XmlNodes = new List<string> { "brand", "model", "color", "price" };
            for (int i = 0; i < dgView.Items.Count; i++)
            {
                Xml.WriteStartElement("car");
                DataGridRow Row = (DataGridRow)dgView.ItemContainerGenerator.ContainerFromIndex(i);
                for (int c = 1; c < dgView.Columns.Count; c++)
                {
                    TextBlock cellContent = dgView.Columns[c].GetCellContent(Row) as TextBlock;

                    Xml.WriteStartElement(XmlNodes.ElementAt(c - 1));
                    Xml.WriteString(cellContent.Text);
                    Xml.WriteEndElement();
                    //Console.WriteLine(cellContent.Text);
                }
                Xml.WriteEndElement();
            }

            Xml.WriteEndDocument();
            Xml.Close();
        }

        private void SaveXMLFile()
        {
            SaveFileDialog Sfd = new SaveFileDialog
            {
                FileName = "",
                Filter = "XML (*.xml)|*.xml"
            };
            if (true == Sfd.ShowDialog())
            {
                string Filename = Sfd.FileName;
                SaveToXML(Filename);
            }
        }

        private bool LoadXMLToList(string Path)
        {
            bool Ret = true;

            XmlDocument Xml = new XmlDocument();

            Xml.Load(Path);


            string XMLBrand;
            string XMLModel;
            string XMLColor;
            int XMLPrice;

            int XMLRecordsCnt = Xml.GetElementsByTagName("car").Count;

            for (int i = 0; i < XMLRecordsCnt; i++)
            {
                try
                {
                    XMLBrand = Xml.GetElementsByTagName("brand").Item(i).InnerText.ToString();
                    XMLModel = Xml.GetElementsByTagName("model").Item(i).InnerText.ToString();
                    XMLColor = Xml.GetElementsByTagName("color").Item(i).InnerText.ToString();
                    XMLPrice = int.Parse(Xml.GetElementsByTagName("price").Item(i).InnerText.ToString());

                    Cars.Add(new Car()
                    {
                        Nbr = i + 1,
                        Brand = XMLBrand,
                        Model = XMLModel,
                        Color = XMLColor,
                        Price = XMLPrice
                    });

                }
                catch (Exception ex)
                {
                    Ret = false;
                    Console.WriteLine(ex.ToString());
                }
            }
            return Ret;
        }

    }
}
