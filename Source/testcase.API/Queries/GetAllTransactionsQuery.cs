using MediatR;
using System.Collections.Generic;
using testcase.API.Models;

namespace testcase.API.Queries
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<Transaction>>
    {       
    }
}
