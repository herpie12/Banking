using Account.Services.DtoModels;
using MediatR;
using System.Collections.Generic;

namespace Account.Services.Queries
{
    public record GetAccountListQuery() : IRequest<IEnumerable<AccountDto>>;
}
