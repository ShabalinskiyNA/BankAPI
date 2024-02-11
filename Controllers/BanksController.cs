using HackathonTask.Models.MyApp;
using HackathonTask.Services;
using HackathonTask.Services.BankInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackathonTask.Controllers
{
    [Route("api/banks")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> AvailiableBanks() 
        {
            return new BanksService().GetAvailiableBanksNames();        
        }
        
        [HttpGet("{bankName}/currencies")]
        public Task<IEnumerable<string>> GetAvailableCurrencies(string bankName)
        {
            return new BanksService().GetCurrencies(bankName);            
        }

        [HttpGet("rate/{bankName}/{cur}/{date}")]
        public Task<RateModel> GetRateByDate(string bankName, string cur, DateTime date )
        {
            return new BanksService().GetByDate(bankName, cur, date);            
        }
    }
}
