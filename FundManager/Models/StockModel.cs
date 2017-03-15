using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections;
using System.Linq;
using System.Text;

namespace FundManager.Models
{
    enum StockType {Equity, Bond}

    public class Stock : INotifyPropertyChanged
    {
        #region Attributes

        private string _stockType;
        private string _stockName;
        private double _price;
        private int _quantity;
        private double _marketValue;
        private double _transactionCost;
        private double _stockWeight;

        #endregion

        #region Constructor

        public Stock(string pStockType, double pPrice, int pQuantity, string pStockName, double pMarketValue, double pTransactionCost, double pStockWeight)
        {
            this._stockType = pStockType;
            this._price = pPrice;
            this._quantity = pQuantity;
            this._stockName = pStockName;
            this._marketValue = pMarketValue;
            this._transactionCost = pTransactionCost;
            this._stockWeight = pStockWeight;
        }

        #endregion

        #region Properties

        public string StockType
        {
            get
            {
                return this._stockType;
            }
            set
            {
                this._stockType = value;
                NotifyPropertyChanged("StockType");
            }
        }

        public string StockName
        {
            get
            {
                return this._stockName;
            }
            private set
            {
                this._stockName = value;
                NotifyPropertyChanged("StockName");
            }
        }

        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
                NotifyPropertyChanged("Price");
            }
        }

        public int Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                this._quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        public double MarketValue
        {
            get
            {
                return this._marketValue;
            }
            private set
            {
                this._marketValue = value;
                NotifyPropertyChanged("MarketValue");
            }
        }

        public double TransactionCost
        {
            get
            {
                return this._transactionCost;
            }
            private set
            {
                this._transactionCost = value;
                NotifyPropertyChanged("TransactionCost");
            }
        }

        public double StockWeight
        {
            get
            {
                return this._stockWeight;
            }
            set
            {
                this._stockWeight = value;
                NotifyPropertyChanged("StockWeight");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    public class StocksModel : ObservableCollection<Stock>, INotifyPropertyChanged
    {
        #region Attributes

        private static object _token = new Object();
        private static StocksModel _current = null;
        private double _equityTotalNumber;
        private double _equityTotalStockWeight;
        private double _equityTotalMarket;
        private double _bondTotalNumber;
        private double _bondTotalStockWeight;
        private double _bondTotalMarket;
        private double _allTotalNumber;
        private double _allTotalStockWeight;
        private double _allTotalMarket;

        #endregion

        #region Construntor

        public static StocksModel Current
        {
            get
            {
                lock (_token)
                    if (_current == null)
                        _current = new StocksModel();

                return _current;
            }
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.RefreshNumbers();
            base.OnCollectionChanged(e);
        }

        #endregion

        #region Properties

        public double EquityTotalNumber
        {
            get
            {
                return this._equityTotalNumber;
            }
            private set
            {
                if (value != this._equityTotalNumber)
                {
                    this._equityTotalNumber = value;
                    NotifyPropertyChanged("EquityTotalNumber");
                }
            }
        }

        public double EquityTotalStockWeight
        {
            get
            {
                return this._equityTotalStockWeight;
            }
            private set
            {
                if (value != this._equityTotalStockWeight)
                {
                    this._equityTotalStockWeight = value;
                    NotifyPropertyChanged("EquityTotalStockWeight");
                }
            }
        }

        public double EquityTotalMarket
        {
            get
            {
                return this._equityTotalMarket;
            }
            private set
            {
                if (value != this._equityTotalMarket)
                {
                    this._equityTotalMarket = value;
                    NotifyPropertyChanged("EquityTotalMarket");
                }
            }
        }

        public double BondTotalNumber
        {
            get
            {
                return this._bondTotalNumber;
            }
            private set
            {
                if (value != this._bondTotalNumber)
                {
                    this._bondTotalNumber = value;
                    NotifyPropertyChanged("BondTotalNumber");
                }
            }
        }

        public double BondTotalStockWeight
        {
            get
            {
                return this._bondTotalStockWeight;
            }
            private set
            {
                if (value != this._bondTotalStockWeight)
                {
                    this._bondTotalStockWeight = value;
                    NotifyPropertyChanged("BondTotalStockWeight");
                }
            }
        }

        public double BondTotalMarket
        {
            get
            {
                return this._bondTotalMarket;
            }
            private set
            {
                if (value != this._bondTotalMarket)
                {
                    this._bondTotalMarket = value;
                    NotifyPropertyChanged("BondTotalMarket");
                }
            }
        }

        public double AllTotalNumber
        {
            get
            {
                return this._allTotalNumber;
            }
            private set
            {
                if (value != this._allTotalNumber)
                {
                    this._allTotalNumber = value;
                    NotifyPropertyChanged("AllTotalNumber");
                }
            }
        }

        public double AllTotalStockWeight
        {
            get
            {
                return this._allTotalStockWeight;
            }
            private set
            {
                if (value != this._allTotalStockWeight)
                {
                    this._allTotalStockWeight = value;
                    NotifyPropertyChanged("AllTotalStockWeight");
                }
            }
        }

        public double AllTotalMarket
        {
            get
            {
                return this._allTotalMarket;
            }
            private set
            {
                if (value != this._allTotalMarket)
                {
                    this._allTotalMarket = value;
                    NotifyPropertyChanged("AllTotalMarket");
                }
            }
        }

        #endregion

        #region Public Methods

        public void AddStock(string pStockType, double pPrice, int pQuantity)
        {
            string stockName = this.GenerateStockName(pStockType);
            double marketValue = this.CalcMarketValue(pPrice, pQuantity);
            double transactionCost = this.CalcTransactionCost(pStockType, pPrice, pQuantity);
            double stockWeight = this.CalcStockWeight(pPrice, pQuantity);
            Stock stock = new Stock(pStockType, pPrice, pQuantity, stockName, marketValue, transactionCost, stockWeight);
            Add(stock);
        }

        public void RefreshNumbers()
        {
            int x = 0;
            for (x = 0; x < this.Items.Count; x++)
            {
                double stockWeight = this.CalcStockWeight(this.Items[x].Price, this.Items[x].Quantity);
                this.Items[x].StockWeight = stockWeight;
            }

            this.EquityTotalNumber = this.CalcTotalNumberByStockType("Equity");
            this.EquityTotalStockWeight = this.CalcTotalStockWeightByStockType("Equity");
            this.EquityTotalMarket = this.CalcTotalMarketValueByStockType("Equity");

            this.BondTotalNumber = this.CalcTotalNumberByStockType("Bond");
            this.BondTotalStockWeight = this.CalcTotalStockWeightByStockType("Bond");
            this.BondTotalMarket = this.CalcTotalMarketValueByStockType("Bond");

            this.AllTotalNumber = this.CalcTotalNumberByStockType();
            this.AllTotalStockWeight = this.CalcTotalStockWeightByStockType();
            this.AllTotalMarket = this.CalcTotalMarketValueByStockType();
        }

        #endregion

        #region Private Methods

        private string GenerateStockName(string pStockType)
        {
            int count = this.Items.Count(x => x.StockType == pStockType);
            return (count == 0) ? pStockType + "1" : pStockType + (count + 1);
        }

        private double CalcMarketValue(double pPrice, int pQuantity)
        {
            return pPrice * pQuantity;
        }

        private double CalcTransactionCost(string pStockType, double pPrice, int pQuantity)
        {
            double marketValue = this.CalcMarketValue(pPrice, pQuantity);
            if (pStockType == "Bond")
            {
                return marketValue * 0.02;
            }
            else if (pStockType == "Equity")
            {
                return marketValue * 0.005;
            }
            else
            {
                return 0;
            }
        }

        private double CalcStockWeight(double pPrice, int pQuantity)
        {
            double marketValue = this.CalcMarketValue(pPrice, pQuantity);
            double totalMarketValue = this.Count > 0 ? this.Items.Sum(x => x.MarketValue) : marketValue;
            return totalMarketValue != 0 ? ((marketValue * 100) / totalMarketValue) : 0;
        }

        private double CalcTotalNumberByStockType(string pStockType="ALL")
        {
            return pStockType == "ALL" ? this.Items.Count() : this.Items.Count(x => x.StockType == pStockType);
        }

        private double CalcTotalStockWeightByStockType(string pStockType = "ALL")
        {
            return pStockType == "ALL" ? this.Items.Sum(x => x.StockWeight) : this.Items.Where(x => x.StockType == pStockType).Sum(x => x.StockWeight);
        }

        private double CalcTotalMarketValueByStockType(string pStockType = "ALL")
        {
            return pStockType == "ALL" ? this.Items.Sum(x => x.MarketValue) : this.Items.Where(x => x.StockType == pStockType).Sum(x => x.MarketValue);
        }

        #endregion
    }
 
}
