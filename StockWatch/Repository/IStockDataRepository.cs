using System.Threading.Tasks;

namespace StockWatch.Repository
{
    public interface IStockDataRepository
    {
        Task<string> LookupStockName(string stockName);

        Task<string> GetStockQuoteDetails(string stockName);
    }
}