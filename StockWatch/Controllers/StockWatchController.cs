using StockWatch.Repository;
using System.Threading.Tasks;
using System.Web.Http;

namespace StockWatch.Api
{
    [RoutePrefix("api/stockwatch")]
    public class StockWatchController : ApiController
    {
        private IStockDataRepository stockDataRepository;
        
        public StockWatchController(IStockDataRepository stockDataRepository) 
        {
            this.stockDataRepository = stockDataRepository;
        }

        [Route("lookup")]
        public async Task<IHttpActionResult> GetStockLookup(string query)
        {
            var result = await stockDataRepository.LookupStockName(query);

            if (!string.IsNullOrEmpty(result))
                return Ok(result);

            return NotFound();
        }

        [Route("quote")]
        public async Task<IHttpActionResult> GetStockQuote(string symbol)
        {
            var result = await stockDataRepository.GetStockQuoteDetails(symbol);

            if (!string.IsNullOrEmpty(result))
                return Ok(result);

            return NotFound();
        }
    }
}
