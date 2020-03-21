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
        public IEnumerable<int> Get()
        {
            int[] temp = { 1, 2, 3};
            return temp;
        }
    }
}