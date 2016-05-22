using StockWatch.Repository;
using System.Threading.Tasks;
using System.Web.Http;

namespace StockWatch.Api
{
    public class StockWatchController : ApiController
    {
        private IStockDataRepository stockDataRepository;
        
        public StockWatchController(IStockDataRepository stockDataRepository) 
        {
            this.stockDataRepository = stockDataRepository;
        }

        public async Task<IHttpActionResult> GetStockLookup(string query)
        {
            var result = await stockDataRepository.LookupStockName(query);

            if (!string.IsNullOrEmpty(result))
                return Ok(result);

            return NotFound();
        }
    }
}
