using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Context;
using testcase.API.Models;
using testcase.API.Queries;

namespace testcase.API.Handlers
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, Transaction>
    {
        private readonly ApplicationContext _context;
        public GetTransactionByIdHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions.Where(x => x.TransactionId == request.Id).FirstOrDefaultAsync();
            if (transaction == null)
            {
                return null;
            }
            return transaction;
        }
    }
}
