using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using FundManager.ViewModels;
using FundManager.Models;
using System.Data;

namespace FundManager.Views
{
    /// <summary>
    /// Interaction logic for StockView.xaml
    /// </summary>
    public partial class StockView : Window
    {
        public StockView()
        {
            InitializeComponent();
            DataContext = new StockViewModel();
        }

        private Color GetCellBgColor(Stock dataRow)
        {
            Color cellBgColor = Colors.White;
            if (dataRow != null && dataRow.StockType == "Bond")
            {
                if ((dataRow.MarketValue < 0) || (dataRow.TransactionCost > 100000))
                {
                    cellBgColor = Colors.Red;
                }
            }
            else if (dataRow != null && dataRow.StockType == "Equity")
            {
                if ((dataRow.MarketValue < 0) || (dataRow.TransactionCost > 200000))
                {
                    cellBgColor = Colors.Red;
                }
            }
            return cellBgColor;
        }

        private void OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                var collection = dgrdStock.ItemsSource;
                foreach (var rowData in collection)
                {
                    foreach (var col in dgrdStock.Columns)
                    {
                        var content = col.GetCellContent(rowData);
                        if (content != null && col.Header.Equals("Stock Name"))
                        {
                            DataGridCell cell = content.Parent as DataGridCell;
                            cell.Background = new SolidColorBrush(this.GetCellBgColor((FundManager.Models.Stock)rowData));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric((TextBox)sender, e);
        }

        private void CheckIsNumeric(TextBox sender,TextCompositionEventArgs e)
        {
            decimal result;
            bool dot = sender.Text.IndexOf(".") < 0 && e.Text.Equals(".") && sender.Text.Length > 0;
            bool minus = sender.Text.IndexOf("-") == -1 && e.Text.Equals("-") && sender.Text.Length == 0;
            bool plus = sender.Text.IndexOf("+") == -1 && e.Text.Equals("+") && sender.Text.Length == 0;
            if (!(Decimal.TryParse(e.Text, out result) || minus || dot))
            {
                e.Handled = true;
            }
        }
    }
}
