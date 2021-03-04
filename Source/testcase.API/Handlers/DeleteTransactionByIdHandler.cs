using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Commands;
using testcase.API.Context;
using testcase.API.Models;

namespace testcase.API.Handlers
{
    public class DeleteTransactionByIdHandler : IRequestHandler<DeleteTransactionByIdCommand, Transaction>
    {
        private readonly ApplicationContext _context;
        public DeleteTransactionByIdHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Transaction> Handle(DeleteTransactionByIdCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions.Where(x => x.TransactionId == request.Id).FirstOrDefaultAsync();
            if (transaction == null)
            {
                return default;
            }
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
