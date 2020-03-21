using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Z1_Lib;

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

        [HttpPost]
        [Route("transfermoneyin")]
        public IActionResult TransferMoneyIn([FromBody] decimal amount)
        {
            try
            {
                _account.TransferMoneyIn(amount);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);//
            }

            return Ok();
        }

        [HttpPost]
        [Route("transfermoneyout")]
        public IActionResult TransferMoneyOut([FromBody] decimal amount)
        {
            try
            {
                _account.TransferMoneyOut(amount);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);//
            }

            return Ok();
        }
    }
}