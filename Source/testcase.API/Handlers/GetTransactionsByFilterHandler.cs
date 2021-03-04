using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Context;
using testcase.API.Models;
using testcase.API.Queries;

namespace testcase.API.Handlers
{
    public class GetTransactionsByFilterHandler : IRequestHandler<GetTransactionsByFilterQuery, IEnumerable<Transaction>>
    {
        private readonly ApplicationContext _context;
        public GetTransactionsByFilterHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsByFilterQuery request, CancellationToken cancellationToken)
        {
            var transactionList = await _context.Transactions.Where(x => x.Status.Contains(request.StatusFilter)
                                                                      && x.Type.Contains(request.TypeFilter)).ToListAsync();
            if (transactionList == null)
            {
                return null;
            }
            return transactionList.AsReadOnly();
        }
    }
}
