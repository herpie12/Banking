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
using Quartz;
using Account.Infrastructure.BackgroundJobs;
using MassTransit;

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


            //Quartz schedule job
            service.AddQuartz(q =>
            {

                var jobkey = new JobKey(nameof(ProcessOutboxMessagesJob));

                q.AddJob<ProcessOutboxMessagesJob>(jobkey)
                .AddTrigger(
                    trigger =>
                       trigger.ForJob(jobkey.Name)
                        .WithSimpleSchedule(
                            schedule =>
                                schedule.WithIntervalInSeconds(10)
                                    .RepeatForever()));

                q.UseMicrosoftDependencyInjectionJobFactory();
            });

            ////// ASP.NET Core hosting
            //service.AddQuartzServer(options =>
            //{
            //    // when shutting down we want jobs to complete gracefully
            //    options.WaitForJobsToComplete = true;
            //});
            service.AddQuartzHostedService();

            // MassTransit-RabbitMQ Configuration
            service.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host("amqp://guest:guest@localhost:5672");
                });
            });
        }
    }
}
