using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new Dictionary<string, Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public Dictionary<string, Stock> Portfolio { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (!IsStockExists(stock.CompanyName)
                && stock.MarketCapitalization > 10000
                && this.MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock.CompanyName, stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!IsStockExists(companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock toSell = Portfolio[companyName];

            if (sellPrice < toSell.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.MoneyToInvest += sellPrice;
            Portfolio.Remove(toSell.CompanyName);

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
            => Portfolio.Values.Where(x => x.CompanyName == companyName).FirstOrDefault();
            //=> IsStockExists(companyName) ? Portfolio[companyName] : null;

        public Stock FindBiggestCompany()
            => Portfolio.Values.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var (_, stock) in Portfolio)
            {
                output.AppendLine(stock.ToString().TrimEnd());
            }
           
            return output.ToString().TrimEnd();
        }

        private bool IsStockExists(string companyName)
            => Portfolio.ContainsKey(companyName);

    }
}
