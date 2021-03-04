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
    public class UpdateTransactionByIdHandler : IRequestHandler<UpdateTransactionByIdCommand, Transaction>
    {
        private readonly ApplicationContext _context;
        public UpdateTransactionByIdHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Transaction> Handle(UpdateTransactionByIdCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions.Where(x => x.TransactionId == request.Id).FirstOrDefaultAsync();
            if (transaction == null)
            {
                return default;
            }
            transaction.Status = request.Status;
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
