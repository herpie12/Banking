using Account.Application.DtoModels;
using MediatR;
using System.Collections.Generic;

namespace Account.Application.Queries
{
    public record GetAccountListQuery() : IRequest<IEnumerable<AccountDto>>;
}
