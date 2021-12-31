using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoleDealerAccountStatement.Controllers
{
    [ApiController]
    [Route("/api/statements")]
    public class StatementsController : ControllerBase
    {
        
        private readonly ILogger<StatementsController> _logger;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public StatementsController(ILogger<StatementsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("FetchStatement")]
        public async Task<ActionResult<IEnumerable<AccountStatement>>> FetchStatement(Statement statement)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int statementDays = (int)(statement.EndDate - statement.StartDate).TotalDays;
            if (statementDays % 2 != 0)
            {
                statementDays = statementDays + 1;
            }
            var statements = new List<AccountStatement>();
            for(int i = 0; i <= statementDays; i++)
            {
                if (i % 2 != 0)
                {
                    statements.Add(new AccountStatement
                    {
                        AccountNumber = i + "00023456",
                        Amount = i + 5400,
                        DestinationAccount = i + "00023456",
                        SourceAccount = i + "0120089",
                        Id = i,
                        TransactionDate = DateTime.Now.AddDays(-i),
                        TransactionDetails = "Receipt from SDACCNST" + i + "0006789",
                        TransactionType = "Credit"
                    });
                }
                else
                {
                    statements.Add(new AccountStatement
                    {
                        AccountNumber = i + "00023456",
                        Amount = i + 5400,
                        DestinationAccount = i + "0006789",
                        SourceAccount = i + "00023456",
                        Id = i,
                        TransactionDate = DateTime.Now.AddDays(-i),
                        TransactionDetails = "Transfer to SDACCNST" + i + "0006789",
                        TransactionType = "Debit"
                    });
                }
            }
            
            return Ok(statements.ToArray());
        }

        [HttpGet("GetWether")]
        public IEnumerable<WeatherForecast> GetWether()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
