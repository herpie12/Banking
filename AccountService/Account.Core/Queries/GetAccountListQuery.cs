using Account.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Account.Core.Queries
{
   public record GetAccountListQuery() : IRequest<IEnumerable<AccountDto>>;
}
