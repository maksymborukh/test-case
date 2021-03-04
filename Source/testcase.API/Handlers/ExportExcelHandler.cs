using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.ExcelHelper;
using testcase.API.Models;
using testcase.API.Queries;

namespace testcase.API.Handlers
{
    public class ExportExcelHandler : IRequestHandler<ExportExcelQuery, IEnumerable<Transaction>>
    {
        public async Task<IEnumerable<Transaction>> Handle(ExportExcelQuery request, CancellationToken cancellationToken)
        {
            ExportExcel export = new ExportExcel();
            var result = export.Export(request.Transactions, request.Path);

            if (request.Transactions == null)
            {
                return null;
            }
            return result;
        }
    }
}
