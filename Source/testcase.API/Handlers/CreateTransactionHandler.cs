using MediatR;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Commands;
using testcase.API.Context;
using testcase.API.Models;

namespace testcase.API.Handlers
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Transaction>
    {
        private readonly ApplicationContext _context;
        public CreateTransactionHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Transaction> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction();
            transaction.Status = request.Status;
            transaction.Type = request.Type;
            transaction.ClientName = request.ClientName;
            transaction.Amount = request.Amount;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
