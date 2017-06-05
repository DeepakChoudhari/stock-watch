using StockWatch.Repository;
using System.Diagnostics;
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
            if (string.IsNullOrEmpty(query))
                return BadRequest("Required input is null");

            Trace.TraceInformation("[GetStockLookup] Input received - " + query);

            var stopWatch = Stopwatch.StartNew();
            var result = await stockDataRepository.LookupStockName(query);
            var timeTakenForStockLookupCall = stopWatch.ElapsedMilliseconds;

            Trace.TraceInformation(string.Format("[GetStockLookup] Time taken to execute LookupStockName api call for input [{0}] - {1}ms", query, timeTakenForStockLookupCall));

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
