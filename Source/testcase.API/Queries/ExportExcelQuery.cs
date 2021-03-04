using MediatR;
using System.Collections.Generic;
using testcase.API.Models;

namespace testcase.API.Queries
{
    public class ExportExcelQuery : IRequest<IEnumerable<Transaction>>
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public string Path { get; set; }

        public ExportExcelQuery(IEnumerable<Transaction> transactions, string path)
        {
            Transactions = transactions;
            Path = path;
        }
    }
}
