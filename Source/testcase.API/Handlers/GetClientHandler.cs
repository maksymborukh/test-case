using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using testcase.API.Context;
using testcase.API.Queries;

namespace testcase.API.Handlers
{
    public class GetClientHandler : IRequestHandler<GetClientQuery, IEnumerable<string>>
    {
        private readonly ApplicationContext _context;
        public GetClientHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<string>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var transactionList = await _context.Transactions.Where(x => x.ClientName.Contains(request.Name)).Select(x => x.ClientName).ToListAsync();
            if (transactionList == null)
            {
                return null;
            }

            return transactionList;
        }
    }
}
