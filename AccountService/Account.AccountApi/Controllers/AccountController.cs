using Account.AccountApi.RequestModels;
using Account.AccountApi.ResponseModels;
using Account.Core.Commands;
using Account.Core.Models;
using Account.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public AccountController(ILogger<AccountController> logger, IMediator mediator, IDistributedCache distributedCach)
        {
            _logger = logger;
            _mediator = mediator;
            _distributedCache = distributedCach;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountDto>> Get()
        {
            return await _mediator.Send(new GetAccountListQuery());
        }

        [HttpPost]
        public async Task<int> CreateAccount([FromBody] AccountDto accountDto)
        {
            return await _mediator.Send(new CreateAccountCommand(accountDto));
        }

        [HttpPut("withdraw")]
        public async Task<decimal> Withdraw([FromBody] AccountWithdraw accountWithdraw)
        {
            return await _mediator.Send(new WithdrawCommand(accountWithdraw.Amount, accountWithdraw.AccountId));
        }

        [HttpGet("redis")]
        public async Task<IActionResult> GetAccountsUsingRedisCache()
        {
            var cacheKey = "AccountList";
            string serializedAccounts;
            var accountList = new List<AccountReponse>();
            var redisAccounts = await CheckRedisCache(cacheKey);

            if (redisAccounts != null)
            {
                serializedAccounts = Encoding.UTF8.GetString(redisAccounts);
                accountList = JsonConvert.DeserializeObject<List<AccountReponse>>(serializedAccounts);
            }
            else
            {
                var accountDtos = await _mediator.Send(new GetAccountListQuery());
                //TODO use automapper
                accountList = accountDtos.Select(z => new AccountReponse { AccountNo = z.AccountNo, AccountType = z.AccountType, Balance = z.Balance, Status = z.Status.ToString() }).ToList();

                serializedAccounts = JsonConvert.SerializeObject(accountList);
                redisAccounts = Encoding.UTF8.GetBytes(serializedAccounts);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisAccounts, options);
            }

            return Ok(accountList);
        }

        private async Task<byte[]> CheckRedisCache(string cacheKey)
        {
            return await _distributedCache.GetAsync(cacheKey);
        }
    }
}
