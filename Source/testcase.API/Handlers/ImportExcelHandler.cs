using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Commands;
using testcase.API.Context;
using testcase.API.ExcelHelper;
using testcase.API.Models;

namespace testcase.API.Handlers
{
    public class ImportExcelHandler : IRequestHandler<ImportExcelCommand, IEnumerable<Transaction>>
    {
        private readonly ApplicationContext _context;
        public ImportExcelHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> Handle(ImportExcelCommand request, CancellationToken cancellationToken)
        {

            ImportExcel csvDate = new ImportExcel();
            List<Transaction> transactions = csvDate.Import(request.Path).ToList();

            StringBuilder builder = new StringBuilder();

            foreach (Transaction transaction in transactions)
            {
                builder.Append(($"('{transaction.TransactionId}', '{transaction.Status}', '{transaction.Type}', '{transaction.ClientName}', '{transaction.Amount}'),"));
            }

            builder.Length = builder.Length - 1;

            _context.Database.ExecuteSqlRaw("INSERT INTO \"Transactions\" " +
                "(\"TransactionId\", \"Status\", \"Type\", \"ClientName\", \"Amount\") " +
                $"VALUES{builder} " +
                "ON Conflict(\"TransactionId\")" +
                $"DO UPDATE SET \"Status\" = excluded.\"Status\" ; ").ToString();

            await _context.SaveChangesAsync();

            if (transactions == null)
            {
                return null;
            }

            return transactions;
        }
    }
}
