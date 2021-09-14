﻿using Account.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core
{
   public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAccounts();

        Task<int> CreateAccount(AccountDto accountDto);
    }
}
