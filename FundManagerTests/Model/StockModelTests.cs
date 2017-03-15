using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManager.Models;

namespace FundManagerTests
{
    [TestClass]
    public class StockModelTests
    {
        [TestMethod]
        public void CreateNewStockTest()
        {
            string stockType = "Bond";
            string stockName = "Bond1";
            double price = 10;
            int quantity = 10;
            double marketValue = 100;
            double transactionCost = 2;
            double stockWeight = 100;

            Stock stock = new Stock(stockType, price, quantity, stockName, marketValue, transactionCost, stockWeight);
            Assert.AreEqual(stockType, stock.StockType, "Incorrect Stock Type");
            Assert.AreEqual(stockName, stock.StockName, "Incorrect Stock Name");
            Assert.AreEqual(price, stock.Price, "Incorrect Price");
            Assert.AreEqual(quantity, stock.Quantity, "Incorrect Quantity");
            Assert.AreEqual(marketValue, stock.MarketValue, "Incorrect Market Value");
            Assert.AreEqual(transactionCost, stock.TransactionCost, "Incorrect Transaction Cost");
            Assert.AreEqual(stockWeight, stock.StockWeight, "Incorrect Stock Weight"); 
        }

        [TestMethod]
        public void CreateNewStockModelTest()
        {
            StocksModel stockModel = new StocksModel();
            Assert.AreEqual(0, stockModel.Count);
        }

        [TestMethod]
        public void AddBondStockTest()
        {
            string stockType = "Bond";
            double price = 10;
            int quantity = 10;

            StocksModel stockModel = new StocksModel();
            stockModel.AddStock(stockType, price, quantity);

            Assert.AreEqual("Bond1", stockModel[0].StockName, "Incorrect Stock Name Generated");
            Assert.AreEqual(100, stockModel[0].MarketValue, "Incorrect Market Value Calculated");
            Assert.AreEqual(2, stockModel[0].TransactionCost, "Incorrect Transaction Cost Calculated");
            Assert.AreEqual(100, stockModel[0].StockWeight, "Incorrect Stock Weight Calculated");

            stockType = "Bond";
            price = 10;
            quantity = 10;
            stockModel.AddStock(stockType, price, quantity);
            Assert.AreEqual("Bond2", stockModel[1].StockName, "Incorrect Stock Name Generated");
            Assert.AreEqual(100, stockModel[1].MarketValue, "Incorrect Market Value Calculated");
            Assert.AreEqual(2, stockModel[1].TransactionCost, "Incorrect Transaction Cost Calculated");
            Assert.AreEqual(50, stockModel[1].StockWeight, "Incorrect Stock Weight Calculated");

        }

        [TestMethod]
        public void AddEquityStockTest()
        {
            string stockType = "Equity";
            double price = 10;
            int quantity = 10;

            StocksModel stockModel = new StocksModel();
            stockModel.AddStock(stockType, price, quantity);

            Assert.AreEqual("Equity1", stockModel[0].StockName, "Incorrect Stock Name Generated");
            Assert.AreEqual(100, stockModel[0].MarketValue, "Incorrect Market Value Calculated");
            Assert.AreEqual(0.5, stockModel[0].TransactionCost, "Incorrect Transaction Cost Calculated");
            Assert.AreEqual(100, stockModel[0].StockWeight, "Incorrect Stock Weight Calculated");

            stockType = "Equity";
            price = 10;
            quantity = 10;
            stockModel.AddStock(stockType, price, quantity);
            Assert.AreEqual("Equity2", stockModel[1].StockName, "Incorrect Stock Name Generated");
            Assert.AreEqual(100, stockModel[1].MarketValue, "Incorrect Market Value Calculated");
            Assert.AreEqual(0.5, stockModel[1].TransactionCost, "Incorrect Transaction Cost Calculated");
            Assert.AreEqual(50, stockModel[1].StockWeight, "Incorrect Stock Weight Calculated");
        }

        [TestMethod]
        public void FundLevelSummaryTest()
        {
            string stockType = "Bond";
            double price = 10;
            int quantity = 10;

            StocksModel stockModel = new StocksModel();
            stockModel.AddStock(stockType, price, quantity);

            stockType = "Bond";
            price = 10;
            quantity = 10;
            stockModel.AddStock(stockType, price, quantity);

            stockType = "Equity";
            price = 10;
            quantity = 10;
            stockModel.AddStock(stockType, price, quantity);

            stockType = "Equity";
            price = 10;
            quantity = 10;
            stockModel.AddStock(stockType, price, quantity);

            Assert.AreEqual(2, stockModel.EquityTotalNumber, "Incorrect Equity Total Number");
            Assert.AreEqual(50, stockModel.EquityTotalStockWeight, "Incorrect Equity Total Stock Weight");
            Assert.AreEqual(200, stockModel.EquityTotalMarket, "Incorrect Equity Total Market Value");
            Assert.AreEqual(2, stockModel.BondTotalNumber, "Incorrect Bond Total Number");
            Assert.AreEqual(50, stockModel.BondTotalStockWeight, "Incorrect Bond Total Stock Weight");
            Assert.AreEqual(200, stockModel.BondTotalMarket, "Incorrect Bond Total Market Value");
            Assert.AreEqual(4, stockModel.AllTotalNumber, "Incorrect Bond Total Number");
            Assert.AreEqual(100, stockModel.AllTotalStockWeight, "Incorrect All Total Stock Weight");
            Assert.AreEqual(400, stockModel.AllTotalMarket, "Incorrect All Total Market Value");
        }
    }
}
