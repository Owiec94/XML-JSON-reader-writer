using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XML_JSON_reader_writer
{
    public partial class MainWindow : Window
    {
        private void DataGridInit()
        {
            dgView.AutoGenerateColumns = false;
            dgView.CanUserAddRows = false;
            dgView.CanUserDeleteRows = false;
        }

        private void LoadDataToDataGrid()
        {
            dgView.ItemsSource = Cars;
            dgView.Items.Refresh();
        }

        private void ClearData()
        {
            Cars.Clear();
        }
    }
}
