using Account.Core;
using Account.Core.Models;
using Account.Core.Queries;
using Account.Core.QueryHandlers;
using Account.Core.CommandHandlers;
using Account.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using MediatR;
using Account.Core.Commands;

namespace Account.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Core layer
            service.AddScoped<IAccountService, AccountService>();

            //Query handlers
            service.AddTransient<GetAccountListHandler>();
            service.AddTransient<IRequestHandler<GetAccountListQuery, IEnumerable<AccountDto>>, GetAccountListHandler>();

            //Command handlers
            service.AddTransient<CreateAccountHandler>();
            service.AddTransient<IRequestHandler<CreateAccountCommand, int>, CreateAccountHandler>();

            service.AddTransient<WithdrawHandler>();
            service.AddTransient<IRequestHandler<WithdrawCommand, decimal>, WithdrawHandler>();
        }
    }
}
