using Account.Core;
using Account.Core.Models;
using Account.Core.Queries;
using Account.Core.QueryHandlers;
using Account.Core.Services;
using Account.Domain.Interfaces;
using Account.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using MediatR;

namespace Account.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Core layer

            service.AddScoped<IAccountService, AccountService>();

            //Data layer

            service.AddScoped<IAccountRepository, AccountRepository>();

            //Query handlers

            service.AddTransient<GetAccountListHandler>();

            service.AddTransient<IRequestHandler<GetAccountListQuery, IEnumerable<AccountDto>>, GetAccountListHandler>();
        }
    }
}
