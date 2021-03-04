using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Context;
using testcase.API.Models;
using testcase.API.Queries;

namespace testcase.API.Handlers
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ApplicationContext _context;
        public GetAllTransactionsHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactionList = await _context.Transactions.ToListAsync();
            if (transactionList == null)
            {
                return null;
            }
            return transactionList.AsReadOnly();
        }
    }
}
