using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using FundManager.Models;
using FundManager.Commands;
using System.Collections.Specialized;

namespace FundManager.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        #region Attributes

        private DelegateCommand exitCommand;
        public StocksModel Stocks { get; set; }
        public string StockType { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        #endregion

        #region Constructor

        public StockViewModel()
        {
            this.Stocks = new StocksModel();
        }

        #endregion

        #region Commands

        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new DelegateCommand(Exit);
                }
                return exitCommand;
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private ICommand _AddStock;
        public ICommand AddStock
        {
            get
            {
                if (_AddStock == null)
                {
                    _AddStock = new DelegateCommand(delegate()
                    {
                        if (StockType.Trim() == String.Empty)
                        {
                            throw new ArgumentException("Stock Type must be selected");
                        }
                        if (Price == 0)
                        {
                            throw new ArgumentException("Specify Price");
                        }
                        if (Quantity == 0)
                        {
                            throw new ArgumentException("Specify Quantity");
                        }

                        Stocks.AddStock(StockType, Price, Quantity);
                    });
                }
                return _AddStock;
            }
        }

        #endregion
    }
}
