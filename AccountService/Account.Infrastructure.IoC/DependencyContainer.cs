
using Account.Domain.Interfaces;
using Account.Infrastructure.Repositories;
using Account.Application.CommandHandlers;
using Account.Application.Commands;
using Account.Application.DtoModels;
using Account.Application.Queries;
using Account.Application.QueryHandlers;
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
