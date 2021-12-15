using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare * totalNumberOfShares;
        }

        public string CompanyName { get; set; }

        public string Director { get; set; }

        public decimal PricePerShare { get; set; }

        public int TotalNumberOfShares { get; set; }

        public decimal MarketCapitalization { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Company: {CompanyName}");
            output.AppendLine($"Director: {Director}");
            output.AppendLine($"Price per share: ${PricePerShare}");
            output.Append($"Market capitalization: ${MarketCapitalization}");
            
            return output.ToString();
        }


    }
}
