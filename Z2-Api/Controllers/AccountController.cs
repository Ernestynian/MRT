using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Z1_Lib;
using Microsoft.AspNetCore.Http;

namespace Z2_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }

        /// <summary>
        /// Shows account status.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AccountStatus Get()
        {
            AccountStatus accountStatus = new AccountStatus();
            accountStatus.Balance = _account.Balance;
            accountStatus.Frozen = _account.Frozen;
            accountStatus.Open = _account.Open;
            accountStatus.Verified = _account.Verified;

            return accountStatus;
        }

        /// <summary>
        /// Transfers given amount of money to increase balance.
        /// </summary>
        /// <param name="amount"></param>
        /// <response code="200"></response>
        /// <response code="400">If amount is lower than 0 or account is closed.</response>
        [HttpPost]
        [Route("transfermoneyin")]
        public IActionResult TransferMoneyIn([FromBody] decimal amount)
        {
            try
            {
                _account.TransferMoneyIn(amount);
            }
            catch(InvalidOperationException e)
            {
                return BadRequest(e.Message);//
            }

            return Ok();
        }

        /// <summary>
        /// Transfers given amount of money to decrease balance.
        /// </summary>
        /// <param name="amount"></param>
        /// <response code="200"></response>
        /// <response code="400">If amount is lower than 0 or account is closed or account is not validated.</response>
        [HttpPost]
        [Route("transfermoneyout")]
        public IActionResult TransferMoneyOut([FromBody] decimal amount)
        {
            try
            {
                _account.TransferMoneyOut(amount);
            }
            catch(InvalidOperationException e)
            {
                return BadRequest(e.Message);//
            }

            return Ok();
        }
    }
}