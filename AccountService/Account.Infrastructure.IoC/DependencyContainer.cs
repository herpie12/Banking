
using Account.Domain.Interfaces;
using Account.Infrastructure.Repositories;
using Account.Services.CommandHandlers;
using Account.Services.Commands;
using Account.Services.DtoModels;
using Account.Services.Queries;
using Account.Services.QueryHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Account.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Core layer
            service.AddScoped<IBankAccountRepository, BankAccountRepository>();

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
